using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.Data;
using ShoppingMall.Models;
using ShoppingMall.ViewModels;

namespace ShoppingMall.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ShoppingMallContext _context;

        public ShopsController(ShoppingMallContext context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index(int id, string searchString, int subcategoryId=0)
        {
            TempData["CategoryId"] = id;
            var shops = _context.Shop.Where(s => s.Subcategory.CategoryId == id);
            var subcategories = _context.Set<Subcategory>().Where(s => s.CategoryId == id);
            if (!string.IsNullOrEmpty(searchString))
                shops = shops.Where(s => s.Name.Contains(searchString));
            if (subcategoryId != 0)
                shops = shops.Where(s => s.Subcategory.Id == subcategoryId);
            shops = shops.Include(s => s.Subcategory).ThenInclude(s => s.Category);
            var viewModel = new ShopsFilterViewModel
            {
                Shops=await shops.ToListAsync(),
                Subcategories = new SelectList(subcategories, "Id", "Name")
            };
            return View(viewModel);
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop
                .Include(s => s.Subcategory)
                .ThenInclude(s=>s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: Shops/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = TempData["CategoryId"];
            string cId = ViewData["CategoryId"].ToString();
            TempData.Keep();
            var subcateries = _context.Subcategory.Where(s => s.CategoryId == Int32.Parse(cId));
            ViewData["SubCategoryId"] = new SelectList(subcateries, "Id", "Name");
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,LogoUrl,ImageUrl,Location,WorkingHours,TelephoneNumber,Email,Description,SubCategoryId")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = TempData["CategoryId"] } );
            }
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", shop.SubCategoryId);
            return View(shop);
        }

        // GET: Shops/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", shop.SubCategoryId);
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LogoUrl,ImageUrl,Location,WorkingHours,TelephoneNumber,Email,Description,SubCategoryId")] Shop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = shop.Id });
            }
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", shop.SubCategoryId);
            return View(shop);
        }

        // GET: Shops/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop
                .Include(s => s.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            TempData["CategoryId"] = shop.Subcategory.CategoryId; 
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shop.FindAsync(id);
            int cId = Int32.Parse(TempData["CategoryId"].ToString());
            _context.Shop.Remove(shop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = cId });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditEmployees(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = _context.Shop.Where(s=>s.Id==id).Include(s=>s.Employees).First();
            if (shop == null)
            {
                return NotFound();
            }

            ShopEmployeesEditViewModel viewmodel = new ShopEmployeesEditViewModel
            {
                Shop = shop,
                EmployeeList = new MultiSelectList(_context.Employee, "Id", "FullName"),
                SelectedEmployees = shop.Employees.Select(sa => sa.EmployeeId)
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditEmployees(int id, ShopEmployeesEditViewModel viewmodel)
        {
            if (id != viewmodel.Shop.Id)
            {
                return NotFound();
            }
            try
            {
                IEnumerable<int> listEmployees = viewmodel.SelectedEmployees;
                IQueryable<Employment> toBeRemoved = _context.Employment.Where(s => !listEmployees.Contains(s.EmployeeId) && s.ShopId == id);
                _context.Employment.RemoveRange(toBeRemoved);
                IEnumerable<int> existEmployees = _context.Employment.Where(s => listEmployees.Contains(s.EmployeeId) && s.ShopId == id).Select(s => s.EmployeeId);
                IEnumerable<int> newEmployees = listEmployees.Where(s => !existEmployees.Contains(s));
                foreach (int employeeId in newEmployees)
                    _context.Employment.Add(new Employment { EmployeeId = employeeId, ShopId = id, StartDate = DateTime.Now });
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(viewmodel.Shop.Id))
                {
                    return NotFound();
                }
                else throw;
            }
            return RedirectToAction("Index", "Employments", new { id = viewmodel.Shop.Id });
        }

        private bool ShopExists(int id)
        {
            return _context.Shop.Any(e => e.Id == id);
        }
    }
}

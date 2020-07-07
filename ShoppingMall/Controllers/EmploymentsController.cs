using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.Data;
using ShoppingMall.Models;
using ShoppingMall.ViewModels;

namespace ShoppingMall.Controllers
{
    public class EmploymentsController : Controller
    {
        private readonly ShoppingMallContext _context;

        public EmploymentsController(ShoppingMallContext context)
        {
            _context = context;
        }

        // GET: Employments
        public async Task<IActionResult> Index(int id, string selectListId)
        {
            var employments = _context.Employment.Where(s => s.ShopId == id);
            Shop shop = _context.Shop.Find(id);
            ViewData["ShopName"] = shop.Name;
            ViewData["ShopId"] = shop.Id;
            if(!string.IsNullOrEmpty(selectListId))
            {
                if (selectListId == "old")
                    employments = employments.Where(s => s.FinishDate != null);
                else if (selectListId=="new")
                    employments = employments.Where(s => s.FinishDate == null);
            }
            employments = employments.Include(e => e.Shop).Include(e => e.Employee).ThenInclude(e => e.Shops).ThenInclude(e => e.Shop);
            var array = new[]
            {
                new SelectListItem {Value="new", Text="Тековни"},
                new SelectListItem {Value="old", Text="Изминати" }
            };
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList = array.ToList();
            var viewModel = new EmployeesInShopFilterViewModel
            {
                Employments = await employments.ToListAsync(),
                SelectList = selectList
            };
            return View(viewModel);
        }

        public async Task<IActionResult> MyEmployments(int id)
        {
            var employments = _context.Employment.Where(s => s.EmployeeId == id);
            employments = employments.Include(e => e.Shop).Include(e => e.Employee);
            return View(await employments.ToListAsync());
        }

        // GET: Employments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employment = await _context.Employment
                .Include(e => e.Employee)
                .Include(e => e.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employment == null)
            {
                return NotFound();
            }

            return View(employment);
        }

        // GET: Employments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "CVUrl");
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Description");
            return View();
        }

        // POST: Employments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShopId,EmployeeId,StartDate,FinishDate,Comment")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "CVUrl", employment.EmployeeId);
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Description", employment.ShopId);
            return View(employment);
        }

        // GET: Employments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employment = await _context.Employment.FindAsync(id);
            if (employment == null)
            {
                return NotFound();
            }
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name", employment.ShopId);
            return View(employment);
        }

        // POST: Employments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employment entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }
            var employment = _context.Employment.FirstOrDefault(s => s.Id == id);
            if (ModelState.IsValid)
            {
                try
                {
                    employment.Comment = entry.Comment;
                    _context.Update(employment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploymentExists(employment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MyEmployments), new { id = employment.EmployeeId });
            }
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name", employment.ShopId);
            return View(employment);
        }

        // GET: Employments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employment = await _context.Employment
                .Include(e => e.Employee)
                .Include(e => e.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employment == null)
            {
                return NotFound();
            }

            return View(employment);
        }

        // POST: Employments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employment = await _context.Employment.FindAsync(id);
            _context.Employment.Remove(employment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploymentExists(int id)
        {
            return _context.Employment.Any(e => e.Id == id);
        }
    }
}

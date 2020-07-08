using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> userManager;
        private IWebHostEnvironment WebHostEnvironment { get; }

        public EmploymentsController(ShoppingMallContext context, UserManager<AppUser> userMgr, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            userManager = userMgr;
            WebHostEnvironment = webHostEnvironment;
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

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> About(int? id)
        {
            if (id == null)
            {
                AppUser curruser = await userManager.GetUserAsync(User);
                if (curruser.EmployeeId != null)
                    return RedirectToAction(nameof(About), new { id = curruser.EmployeeId });
                else
                    return NotFound();
            }
            var employees = _context.Employee.Include(e => e.Shops).ThenInclude(e => e.Shop);
            Employee employee = employees.Where(e => e.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            AppUser user = await userManager.GetUserAsync(User);
            if (employee.Id != user.EmployeeId)
            {
                return RedirectToAction("AccessDenied", "Account", null);
            }
            return View(employee);
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> MyEmployments(int? id)
        {
            if (id == null)
            {
                AppUser curruser = await userManager.GetUserAsync(User);
                if (curruser.EmployeeId != null)
                    return RedirectToAction(nameof(MyEmployments), new { id = curruser.EmployeeId });
                else
                    return NotFound();
            }
            Employee employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            AppUser user = await userManager.GetUserAsync(User);
            if (employee.Id != user.EmployeeId)
            {
                return RedirectToAction("AccessDenied", "Account", null);
            }
            var employments = _context.Employment.Where(s => s.EmployeeId == id);
            employments = employments.Include(e => e.Shop).Include(e => e.Employee);
            return View(await employments.ToListAsync());
        }

        // GET: Employments/Edit/5
        [Authorize(Roles = "Employee")]
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
            AppUser user = await userManager.GetUserAsync(User);
            if (employment.EmployeeId != user.EmployeeId)
            {
                return RedirectToAction("AccessDenied", "Account", null);
            }
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name", employment.ShopId);
            return View(employment);
        }

        // POST: Employments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Edit(int id, Employment entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }
            var employment = _context.Employment.FirstOrDefault(s => s.Id == id);
            if (employment == null)
            {
                return NotFound();
            }
            AppUser user = await userManager.GetUserAsync(User);
            if (employment.EmployeeId != user.EmployeeId)
            {
                return RedirectToAction("AccessDenied", "Account", null);
            }
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
        private string UploadFile(IFormFile file)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "employeeCVs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private bool EmploymentExists(int id)
        {
            return _context.Employment.Any(e => e.Id == id);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}

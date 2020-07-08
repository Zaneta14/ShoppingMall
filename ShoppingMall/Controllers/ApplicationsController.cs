using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.Data;
using ShoppingMall.Models;
using ShoppingMall.ViewModels;

namespace ShoppingMall.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly ShoppingMallContext _context;
        private IWebHostEnvironment WebHostEnvironment { get; }

        public ApplicationsController(ShoppingMallContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        // GET: Applications
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string selectedSort, int shopId = 0)
        {
            IQueryable<Application> applications = _context.Application;
            if (shopId != 0)
                applications = applications.Where(a => a.ShopId == shopId);
            if (!string.IsNullOrEmpty(selectedSort))
            {
                if (selectedSort == "desc")
                    applications = applications.OrderByDescending(a => a.ApplicationDate);
                else if (selectedSort == "asc")
                    applications = applications.OrderBy(a => a.ApplicationDate);
            }
            applications = applications.Include(a => a.Shop);
            var array = new[]
            {
                new SelectListItem {Value="asc", Text="Најстари кон најнови"},
                new SelectListItem {Value="desc", Text="Најнови кон најстари" }
            };
            List<SelectListItem> sorts = new List<SelectListItem>();
            sorts = array.ToList();
            var viewModel = new ApplicationsFilterViewModel
            {
                Applications = await applications.ToListAsync(),
                Shops = new SelectList(_context.Shop, "Id", "Name"),
                Sorts=sorts
            };
            return View(viewModel);
        }

        // GET: Applications/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Application.FindAsync(id);
            _context.Application.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Applications/Create
        public IActionResult Apply()
        {
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(Application entry, IFormFile cvUrl)
        {
            Application application = new Application
            {
                FirstName = entry.FirstName,
                LastName = entry.LastName,
                ShopId = entry.ShopId,
                ApplicationDate = DateTime.Now,
                CVUrl = UploadFile(cvUrl)
            };
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Success));
            }
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name", application.ShopId);
            return View(application);
        }

        public IActionResult Success()
        {
            return View();
        }

        private string UploadFile(IFormFile file)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "applicationCVs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private bool ApplicationExists(int id)
        {
            return _context.Application.Any(e => e.Id == id);
        }
    }
}

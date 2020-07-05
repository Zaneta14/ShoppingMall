using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.Data;
using ShoppingMall.Models;

namespace ShoppingMall.Controllers
{
   // [Roles="Admin"]
    public class EmploymentController : Controller
    {
        private readonly ShoppingMallContext _context;

        public EmploymentController(ShoppingMallContext context)
        {
            _context = context;
        }

        // GET: Employment
        public async Task<IActionResult> Index()
        {
            var shoppingMallContext = _context.Employment.Include(e => e.Employee).Include(e => e.Shop);
            return View(await shoppingMallContext.ToListAsync());
        }

        // GET: Employment/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FullName");
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name");
            return View();
        }

        // POST: Employment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShopId,EmployeeId,StartDate")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FullName", employment.EmployeeId);
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name", employment.ShopId);
            return View(employment);
        }

        // GET: Employment/Edit/5
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FullName", employment.EmployeeId);
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name", employment.ShopId);
            return View(employment);
        }

        // POST: Employment/Edit/5
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
                    
                    employment.FinishDate = entry.FinishDate;
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FullName", employment.EmployeeId);
            ViewData["ShopId"] = new SelectList(_context.Shop, "Id", "Name", employment.ShopId);
            return View(employment);
        }

        // GET: Employment/Delete/5
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

        // POST: Employment/Delete/5
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

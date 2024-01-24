using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var applicationDbContext = _context.Sales.Where(t => t.StaffId == id).Include(s => s.Buyer).Include(s => s.Car).Include(s => s.Staff);
            
            string staff = _context.Staff.FirstOrDefault(t => t.StaffId == id).FullName;

            ViewBag.Staff = staff;
            ViewBag.StaffId = id;
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Buyer)
                .Include(s => s.Car)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["StaffId"] = id;
            
            ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "FullName");
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "ShortInfo");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,CarId,BuyerId,StaffId,SaleDate,Cost")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = sale.StaffId });
            }
            ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "FullName", sale.BuyerId);
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "ShortInfo", sale.CarId);

            ViewData["StaffId"] = sale.StaffId;
                
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "FullName", sale.BuyerId);
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "ShortInfo", sale.CarId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FullName", sale.StaffId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,CarId,BuyerId,StaffId,SaleDate,Cost")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = sale.StaffId });
            }
            ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "FullName", sale.BuyerId);
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "ShortInfo", sale.CarId);
            
            ViewData["StaffId"] = sale.StaffId;
            
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Buyer)
                .Include(s => s.Car)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            int staffId = sale.StaffId;
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = staffId });
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SaleId == id);
        }
    }
}

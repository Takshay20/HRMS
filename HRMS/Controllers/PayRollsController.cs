using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMS.Data;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class PayRollsController : Controller
    {
        private readonly AppDbContext _context;

        public PayRollsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PayRolls
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Payrolls.Include(p => p.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PayRolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payRoll = await _context.Payrolls
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.PayRollId == id);
            if (payRoll == null)
            {
                return NotFound();
            }

            return View(payRoll);
        }

        // GET: PayRolls/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address");
            return View();
        }

        // POST: PayRolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayRollId,EmployeeId,Month,Year,PresentDays,AbsentDays,GrossSalary,Deductions,NetSalary,GeneratedAt")] PayRoll payRoll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payRoll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", payRoll.EmployeeId);
            return View(payRoll);
        }

        // GET: PayRolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payRoll = await _context.Payrolls.FindAsync(id);
            if (payRoll == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", payRoll.EmployeeId);
            return View(payRoll);
        }

        // POST: PayRolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PayRollId,EmployeeId,Month,Year,PresentDays,AbsentDays,GrossSalary,Deductions,NetSalary,GeneratedAt")] PayRoll payRoll)
        {
            if (id != payRoll.PayRollId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payRoll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayRollExists(payRoll.PayRollId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", payRoll.EmployeeId);
            return View(payRoll);
        }

        // GET: PayRolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payRoll = await _context.Payrolls
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.PayRollId == id);
            if (payRoll == null)
            {
                return NotFound();
            }

            return View(payRoll);
        }

        // POST: PayRolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payRoll = await _context.Payrolls.FindAsync(id);
            if (payRoll != null)
            {
                _context.Payrolls.Remove(payRoll);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayRollExists(int id)
        {
            return _context.Payrolls.Any(e => e.PayRollId == id);
        }
    }
}

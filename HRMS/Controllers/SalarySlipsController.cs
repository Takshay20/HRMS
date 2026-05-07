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
    public class SalarySlipsController : Controller
    {
        private readonly AppDbContext _context;

        public SalarySlipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SalarySlips
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SalarySlips.Include(s => s.PayRoll);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SalarySlips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarySlip = await _context.SalarySlips
                .Include(s => s.PayRoll)
                .FirstOrDefaultAsync(m => m.SalarySlipId == id);
            if (salarySlip == null)
            {
                return NotFound();
            }

            return View(salarySlip);
        }

        // GET: SalarySlips/Create
        public IActionResult Create()
        {
            ViewData["PayRollId"] = new SelectList(_context.Payrolls, "PayRollId", "PayRollId");
            return View();
        }

        // POST: SalarySlips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalarySlipId,PayRollId,SlipNumber,PdfPath,GeneratedAt")] SalarySlip salarySlip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salarySlip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PayRollId"] = new SelectList(_context.Payrolls, "PayRollId", "PayRollId", salarySlip.PayRollId);
            return View(salarySlip);
        }

        // GET: SalarySlips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarySlip = await _context.SalarySlips.FindAsync(id);
            if (salarySlip == null)
            {
                return NotFound();
            }
            ViewData["PayRollId"] = new SelectList(_context.Payrolls, "PayRollId", "PayRollId", salarySlip.PayRollId);
            return View(salarySlip);
        }

        // POST: SalarySlips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalarySlipId,PayRollId,SlipNumber,PdfPath,GeneratedAt")] SalarySlip salarySlip)
        {
            if (id != salarySlip.SalarySlipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salarySlip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarySlipExists(salarySlip.SalarySlipId))
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
            ViewData["PayRollId"] = new SelectList(_context.Payrolls, "PayRollId", "PayRollId", salarySlip.PayRollId);
            return View(salarySlip);
        }

        // GET: SalarySlips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarySlip = await _context.SalarySlips
                .Include(s => s.PayRoll)
                .FirstOrDefaultAsync(m => m.SalarySlipId == id);
            if (salarySlip == null)
            {
                return NotFound();
            }

            return View(salarySlip);
        }

        // POST: SalarySlips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salarySlip = await _context.SalarySlips.FindAsync(id);
            if (salarySlip != null)
            {
                _context.SalarySlips.Remove(salarySlip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarySlipExists(int id)
        {
            return _context.SalarySlips.Any(e => e.SalarySlipId == id);
        }
    }
}

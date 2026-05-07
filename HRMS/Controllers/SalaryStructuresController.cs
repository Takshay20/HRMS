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
    public class SalaryStructuresController : Controller
    {
        private readonly AppDbContext _context;

        public SalaryStructuresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SalaryStructures
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SalaryStructures.Include(s => s.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SalaryStructures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryStructure = await _context.SalaryStructures
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.SalaryStructureId == id);
            if (salaryStructure == null)
            {
                return NotFound();
            }

            return View(salaryStructure);
        }

        // GET: SalaryStructures/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address");
            return View();
        }

        // POST: SalaryStructures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryStructureId,EmployeeId,BasicSalary,HRA,DA,TA,Bonus,PF,Tax")] SalaryStructure salaryStructure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryStructure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", salaryStructure.EmployeeId);
            return View(salaryStructure);
        }

        // GET: SalaryStructures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryStructure = await _context.SalaryStructures.FindAsync(id);
            if (salaryStructure == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", salaryStructure.EmployeeId);
            return View(salaryStructure);
        }

        // POST: SalaryStructures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryStructureId,EmployeeId,BasicSalary,HRA,DA,TA,Bonus,PF,Tax")] SalaryStructure salaryStructure)
        {
            if (id != salaryStructure.SalaryStructureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryStructure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryStructureExists(salaryStructure.SalaryStructureId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", salaryStructure.EmployeeId);
            return View(salaryStructure);
        }

        // GET: SalaryStructures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryStructure = await _context.SalaryStructures
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.SalaryStructureId == id);
            if (salaryStructure == null)
            {
                return NotFound();
            }

            return View(salaryStructure);
        }

        // POST: SalaryStructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaryStructure = await _context.SalaryStructures.FindAsync(id);
            if (salaryStructure != null)
            {
                _context.SalaryStructures.Remove(salaryStructure);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryStructureExists(int id)
        {
            return _context.SalaryStructures.Any(e => e.SalaryStructureId == id);
        }
    }
}

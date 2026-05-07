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
    public class EmployeeDocumentsController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeDocumentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDocuments
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EmployeesDocuments.Include(e => e.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EmployeeDocuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDocument = await _context.EmployeesDocuments
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeDocumentId == id);
            if (employeeDocument == null)
            {
                return NotFound();
            }

            return View(employeeDocument);
        }

        // GET: EmployeeDocuments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address");
            return View();
        }

        // POST: EmployeeDocuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeDocumentId,EmployeeId,DocumentName,FilePath,UploadedAt")] EmployeeDocument employeeDocument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDocument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", employeeDocument.EmployeeId);
            return View(employeeDocument);
        }

        // GET: EmployeeDocuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDocument = await _context.EmployeesDocuments.FindAsync(id);
            if (employeeDocument == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", employeeDocument.EmployeeId);
            return View(employeeDocument);
        }

        // POST: EmployeeDocuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeDocumentId,EmployeeId,DocumentName,FilePath,UploadedAt")] EmployeeDocument employeeDocument)
        {
            if (id != employeeDocument.EmployeeDocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDocument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDocumentExists(employeeDocument.EmployeeDocumentId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Address", employeeDocument.EmployeeId);
            return View(employeeDocument);
        }

        // GET: EmployeeDocuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDocument = await _context.EmployeesDocuments
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeDocumentId == id);
            if (employeeDocument == null)
            {
                return NotFound();
            }

            return View(employeeDocument);
        }

        // POST: EmployeeDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDocument = await _context.EmployeesDocuments.FindAsync(id);
            if (employeeDocument != null)
            {
                _context.EmployeesDocuments.Remove(employeeDocument);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDocumentExists(int id)
        {
            return _context.EmployeesDocuments.Any(e => e.EmployeeDocumentId == id);
        }
    }
}

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
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Designation).Include(e => e.Shift).Include(e => e.UserAccount);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Include(e => e.Shift)
                .Include(e => e.UserAccount)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmantId", "DepartpartName");
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationName");
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftName");
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "UserAccountId", "Email");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeCode,FullName,Email,Phone,Gender,DOB,JoiningDate,Address,DepartmentId,DesignationId,ShiftId,UserAccountId,BasicSalary,ProfileImage,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmantId", "DepartpartName", employee.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationName", employee.DesignationId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftName", employee.ShiftId);
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "UserAccountId", "Email", employee.UserAccountId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmantId", "DepartpartName", employee.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationName", employee.DesignationId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftName", employee.ShiftId);
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "UserAccountId", "Email", employee.UserAccountId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeCode,FullName,Email,Phone,Gender,DOB,JoiningDate,Address,DepartmentId,DesignationId,ShiftId,UserAccountId,BasicSalary,ProfileImage,IsActive")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmantId", "DepartpartName", employee.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationName", employee.DesignationId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftName", employee.ShiftId);
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "UserAccountId", "Email", employee.UserAccountId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Include(e => e.Shift)
                .Include(e => e.UserAccount)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}

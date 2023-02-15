
using Employ.Business.Services;
using Employ.Data.Repository;
using EmployeeManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly EmployeeDbContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var x = await _employeeService.GetAllEmploy();
            return View(x);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Email,Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmploy(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _employeeService.GetEmpById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("EmployeeId,Name,Email,Department")] Employee employee)
        {
            if (employee.EmployeeId != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.EditEmploy(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw ;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmploy(id);
            return RedirectToAction(nameof(Index));
        }
        
    }

}

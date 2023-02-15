using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Employ.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmploy()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> CreateEmploy(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Employee> GetEmpById(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }
        public async Task<bool> EditEmploy(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmploy(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

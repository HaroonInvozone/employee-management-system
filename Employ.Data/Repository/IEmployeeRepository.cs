using EmployeeManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employ.Data.Repository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmploy();
        public Task<bool> CreateEmploy(Employee employee);
        public Task<Employee> GetEmpById(int? id);
        public Task<bool> EditEmploy(Employee employee);
        public Task<bool> DeleteEmploy(int? id);
    }
}

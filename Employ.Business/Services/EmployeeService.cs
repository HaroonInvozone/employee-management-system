using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employ.Data.Repository;
using EmployeeManagmentSystem.Models;

namespace Employ.Business.Services
{
    public  class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmploy()
        {
            return await _employeeRepository.GetAllEmploy();
        }
        public async Task<bool> CreateEmploy(Employee employee)
        {
            return await _employeeRepository.CreateEmploy(employee);
        }
        public async Task<Employee> GetEmpById(int? id)
        {
            return await _employeeRepository.GetEmpById(id);
        }
        public async Task<bool> EditEmploy(Employee employee)
        {
            return await _employeeRepository.EditEmploy(employee);
        }
        public async Task<bool> DeleteEmploy(int? id)
        {
            return await _employeeRepository.DeleteEmploy(id);
        }
    }
}

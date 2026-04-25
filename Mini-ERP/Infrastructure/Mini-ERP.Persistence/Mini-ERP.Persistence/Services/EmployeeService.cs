using Microsoft.EntityFrameworkCore;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Repostories;
using Mini_ERP.Domain.Entities;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<bool> AddEmployeeAsync(string Name, string Phone, EmployeeRole Role)
        {
            try
            {
                Name = Name.ToLower();
                var name = await _employeeReadRepository.GetWhere(c => c.Name == Name).FirstOrDefaultAsync();
                string Employeename = name?.Name?.ToLower();
                if (Employeename != null) 
                    return false;
                var newEmployee = new Employee
                {
                    Name = Name.ToLower(),
                    Phone = Phone.ToLower(),
                    Role = Role
                };
                await _employeeWriteRepository.AddAsync(newEmployee);
                await _employeeWriteRepository.SaveAsync();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            List<Employee> employees = await _employeeReadRepository.GetAll(false).ToListAsync();
            return employees;
        }

        public async Task<bool> RemoveEmployeeAsync(int id)
        {
            try
            {
                bool control = await _employeeWriteRepository.RemoveAsync(id);
                await _employeeWriteRepository.SaveAsync();
                return control;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployeeAsync(int id, string Name, string Phone, EmployeeRole Role)
        {
            try
            {
                Employee employee = await _employeeReadRepository.GetByIdAsync(id);
                employee.Name = Name;
                employee.Phone = Phone;
                    employee.Role = Role;
                await _employeeWriteRepository.SaveAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

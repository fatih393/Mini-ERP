using Mini_ERP.Domain.Entities;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Abstractions.Services
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployeeAsync(string Name, string Phone, EmployeeRole Role);
        Task<List<Employee>> GetEmployeeAsync();
        Task<bool> RemoveEmployeeAsync(int id);
        Task<bool> UpdateEmployeeAsync(int id, string Name, string Phone, EmployeeRole Role);
    }
}


/* public string Name { get; set; }
public string Phone { get; set; }
public EmployeeRole Role { get; set; }*/

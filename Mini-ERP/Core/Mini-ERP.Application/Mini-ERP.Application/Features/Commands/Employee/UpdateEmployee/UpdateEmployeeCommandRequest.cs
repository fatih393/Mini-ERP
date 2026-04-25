using MediatR;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest: IRequest<DataResult<UpdateEmployeeCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public EmployeeRole Role { get; set; }
    }
}

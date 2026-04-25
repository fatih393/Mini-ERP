using MediatR;
using Mini_ERP.Application.Abstractions;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, DataResult<CreateEmployeeCommandResponse>>
    {
        readonly IEmployeeService _employeeService;

        public CreateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<DataResult<CreateEmployeeCommandResponse>> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(request.Name, request.Phone, request.Role);
                return new SuccessDataResult<CreateEmployeeCommandResponse>(null, "Employee kaydı başarılı");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CreateEmployeeCommandResponse>("Employee kaydı esnasında bir hata oluştu. Hata kodu = " + ex);
            } 
            
        }
    }
}

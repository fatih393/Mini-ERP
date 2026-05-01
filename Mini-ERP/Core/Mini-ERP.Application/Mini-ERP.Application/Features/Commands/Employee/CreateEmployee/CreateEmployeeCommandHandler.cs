using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetMilkCollection;
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
       readonly ILogger<CreateEmployeeCommandHandler> _logger;

        public CreateEmployeeCommandHandler(IEmployeeService employeeService, ILogger<CreateEmployeeCommandHandler> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<DataResult<CreateEmployeeCommandResponse>> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(request.Name, request.Phone, request.Role);
                _logger.LogInformation("Employee kaydı başarılı");
                return new SuccessDataResult<CreateEmployeeCommandResponse>(null, "Employee kaydı başarılı");
            }
            catch (Exception ex)
            {
                _logger.LogError("Employee kaydı esnasında bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<CreateEmployeeCommandResponse>("Employee kaydı esnasında bir hata oluştu. Hata kodu = " + ex);
            } 
            
        }
    }
}

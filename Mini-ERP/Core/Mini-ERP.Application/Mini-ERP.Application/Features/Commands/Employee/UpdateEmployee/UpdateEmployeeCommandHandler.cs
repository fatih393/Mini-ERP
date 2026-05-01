using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Employee.RemoveEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, DataResult<UpdateEmployeeCommandResponse>>
    {
        readonly IEmployeeService _employeeService;
      readonly ILogger<UpdateEmployeeCommandHandler> _logger;

        public UpdateEmployeeCommandHandler(IEmployeeService employeeService, ILogger<UpdateEmployeeCommandHandler> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<DataResult<UpdateEmployeeCommandResponse>> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _employeeService.UpdateEmployeeAsync(
                        request.Id,
                        request.Name,
                        request.Phone,
                        request.Role

                    );
                _logger.LogInformation("Employee güncelemmesi başarılı");
                return new SuccessDataResult<UpdateEmployeeCommandResponse>(null, "Employee güncelemmesi başarılı");
            }   
            catch (Exception ex)
            {
                _logger.LogError("Employee güncellenirken bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<UpdateEmployeeCommandResponse>("Employee güncellenirken bir hata oluştu. Hata kodu = " + ex);
            }

        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Employee.CreateEmployee;
using Mini_ERP.Application.Features.Commands.Supplier.RemoveSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Employee.RemoveEmployee
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommandRequest, DataResult<RemoveEmployeeCommandResponse>>
    {
        readonly IEmployeeService _employeeService;
      readonly  ILogger<RemoveEmployeeCommandHandler> _logger;

        public RemoveEmployeeCommandHandler(IEmployeeService employeeService, ILogger<RemoveEmployeeCommandHandler> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<DataResult<RemoveEmployeeCommandResponse>> Handle(RemoveEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _employeeService.RemoveEmployeeAsync(request.Id))
                 {
                    _logger.LogError("Silinecek employee bulunamadı ");
                    return new ErrorDataResult<RemoveEmployeeCommandResponse>("Silinecek employee bulunamadı "); 
                }
                _logger.LogInformation("Employee silme işlemi başarılı");
                return new SuccessDataResult<RemoveEmployeeCommandResponse>(null, "Employee silme işlemi başarılı");
            }
            catch (Exception ex)
            {
                _logger.LogError("Employee silerken bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<RemoveEmployeeCommandResponse>("Employee silerken bir hata oluştu. Hata kodu = "+ex);
            }
        }
    }
}

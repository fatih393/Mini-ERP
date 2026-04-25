using MediatR;
using Mini_ERP.Application.Abstractions.Services;
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

        public RemoveEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<DataResult<RemoveEmployeeCommandResponse>> Handle(RemoveEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _employeeService.RemoveEmployeeAsync(request.Id))
                    return new ErrorDataResult<RemoveEmployeeCommandResponse>("Silinecek employee bulunamadı ");
                return new SuccessDataResult<RemoveEmployeeCommandResponse>(null, "Employee silme işlemi başarılı");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<RemoveEmployeeCommandResponse>("Employee silerken bir hata oluştu. Hata kodu = "+ex);
            }
        }
    }
}

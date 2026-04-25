using MediatR;
using Mini_ERP.Application.Abstractions.Services;
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

        public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
                return new SuccessDataResult<UpdateEmployeeCommandResponse>(null, "Employee güncelemmesi başarılı");
            }   
            catch (Exception ex)
            {
                return new ErrorDataResult<UpdateEmployeeCommandResponse>("Employee güncellenirken bir hata oluştu. Hata kodu = " + ex);
            }

        }
    }
}

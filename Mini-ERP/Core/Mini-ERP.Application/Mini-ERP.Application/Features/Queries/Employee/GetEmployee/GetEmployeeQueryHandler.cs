using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Employee.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQueryRequest, DataResult<GetEmployeeQueryResponse>>
    {
        readonly IEmployeeService _employeeService;

        public GetEmployeeQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<DataResult<GetEmployeeQueryResponse>> Handle(GetEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Domain.Entities.Employee> employees = await _employeeService.GetEmployeeAsync();
                return new SuccessDataResult<GetEmployeeQueryResponse>(
                    new GetEmployeeQueryResponse() { employee = employees }, "Employee listeleme başarılı");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetEmployeeQueryResponse>("Employee listelenirken bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

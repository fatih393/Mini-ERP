using MediatR;
using Microsoft.Extensions.Logging;
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
        readonly ILogger<GetEmployeeQueryHandler> _logger;
        public GetEmployeeQueryHandler(IEmployeeService employeeService, ILogger<GetEmployeeQueryHandler> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<DataResult<GetEmployeeQueryResponse>> Handle(GetEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Domain.Entities.Employee> employees = await _employeeService.GetEmployeeAsync();
                _logger.LogInformation("Employees listelendi");
                return new SuccessDataResult<GetEmployeeQueryResponse>(
                    new GetEmployeeQueryResponse() { employee = employees }, "Employee listeleme başarılı");
            }
            catch (Exception ex)
            {
                _logger.LogError("Employee listelenirken bir hata oluştu. Hata kodu =" + ex);
                return new ErrorDataResult<GetEmployeeQueryResponse>("Employee listelenirken bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

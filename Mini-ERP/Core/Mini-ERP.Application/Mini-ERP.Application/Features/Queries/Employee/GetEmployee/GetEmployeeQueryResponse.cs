using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Employee.GetEmployee
{
    public class GetEmployeeQueryResponse
    {
        public List<Domain.Entities.Employee> employee { get; set; }
    }
}

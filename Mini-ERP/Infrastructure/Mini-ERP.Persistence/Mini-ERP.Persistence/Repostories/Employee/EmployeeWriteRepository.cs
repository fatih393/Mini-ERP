using Mini_ERP.Application.Repostories;
using Mini_ERP.Domain.Entities;
using Mini_ERP.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence.Repostories
{
    public class EmployeeWriteRepository : WriteRepostory<Employee>, IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(Mini_ErpAPIContext context) : base(context)
        {
        }
    }
}

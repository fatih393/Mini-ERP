using Mini_ERP.Domain.Entities.Common;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Domain.Entities
{
    public class Employee: BaseEntitiy
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public EmployeeRole Role { get; set; }
       
    }
}

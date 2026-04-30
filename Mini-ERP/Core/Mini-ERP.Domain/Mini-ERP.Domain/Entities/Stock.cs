using Mini_ERP.Domain.Entities.Common;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Domain.Entities
{
    public class Stock: BaseEntitiy
    {
        public string ProductName { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public int? ReferenceId { get; set; }

        public ReferenceType ReferenceType { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}

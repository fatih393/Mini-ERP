using Mini_ERP.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Domain.Entities
{
    public class MilkCollection: BaseEntitiy
    {
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; } // litre
        public decimal FatRate { get; set; }
        public decimal ProteinRate { get; set; }
        public string? Note { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int CollectorEmployeeId { get; set; }
        public Employee CollectorEmployee { get; set; }

        public int? QualityEmployeeId { get; set; }
        public Employee? QualityEmployee { get; set; }
        public bool Status { get; set; } = true; // kabul red

    }
}

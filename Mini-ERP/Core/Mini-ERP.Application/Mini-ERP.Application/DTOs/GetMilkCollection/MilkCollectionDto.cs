using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.DTOs.GetMilkCollection
{
    public class MilkCollectionDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public decimal Quantity { get; set; }
        public decimal FatRate { get; set; }
        public decimal ProteinRate { get; set; }

        public string Note { get; set; }
        public bool Status { get; set; }

     
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

        public int CollectorEmployeeId { get; set; }
        public string CollectorEmployeeName { get; set; }

        public int? QualityEmployeeId { get; set; }
        public string QualityEmployeeName { get; set; }
    }
}

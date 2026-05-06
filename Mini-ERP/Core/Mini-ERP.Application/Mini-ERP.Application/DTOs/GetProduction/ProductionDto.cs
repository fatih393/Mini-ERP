using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.DTOs.GetProduction
{
    public class ProductionDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int ProductionEmployeeId { get; set; }
        public string ProductionEmployeeName { get; set; } 

        public decimal OutputQuantity { get; set; }

        public string Unit { get; set; }

        public decimal ConsumedMilkQuantity { get; set; }
         public string BatchCode { get; set; }

        public DateTime ProductDate { get; set; }
    }
}

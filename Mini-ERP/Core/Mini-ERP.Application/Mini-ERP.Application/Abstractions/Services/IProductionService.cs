using Mini_ERP.Domain.Entities;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Abstractions.Services
{
    public interface IProductionService
    {
        Task<int> AddProductionAsync(ProductName productName, int ProductionEmployeeId, decimal OutputQuantity, Unit unit, decimal ConsumedMilkQuantity, DateTime ProductDate);
        Task<List<Production>> GetProductionAsync();
    
    }



    /*
     
       public ProductName ProductName { get; set; }

        public int ProductionEmployeeId { get; set; }
        public Employee ProductionEmployee { get; set; }

      
        public decimal OutputQuantity { get; set; }

      
        public Unit Unit { get; set; }

       
        public decimal ConsumedMilkQuantity { get; set; }

       
        public DateTime ProductDate { get; set; }

     
     
     */
}

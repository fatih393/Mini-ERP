using Microsoft.EntityFrameworkCore;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Repostories;
using Mini_ERP.Domain.Entities;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence.Services
{
    public class ProductionService : IProductionService
    {
        readonly IProductionReadRepository _productionReadRepository;
        readonly IProductionWriteRepository _productionWriteRepository;

        public ProductionService(IProductionReadRepository productionReadRepository, IProductionWriteRepository productionWriteRepository)
        {
            _productionReadRepository = productionReadRepository;
            _productionWriteRepository = productionWriteRepository;
        }

        public async Task<int> AddProductionAsync(ProductName productName, int ProductionEmployeeId, decimal OutputQuantity, Unit unit, decimal ConsumedMilkQuantity, DateTime ProductDate)
        {
            try
            {
                var newProduction = new Production
                {
                    ProductName = productName,
                    ProductionEmployeeId = ProductionEmployeeId,
                    OutputQuantity = OutputQuantity,
                    Unit = unit,
                    ConsumedMilkQuantity = ConsumedMilkQuantity,
                    ProductDate = DateTime.Now,
                };
                await _productionWriteRepository.AddAsync(newProduction);
                await _productionWriteRepository.SaveAsync();
                return newProduction.Id;
            }
            catch { 
            
                return 0;
            }
        }

        public async Task<List<Production>> GetProductionAsync()
        {
            return await _productionReadRepository.GetAll()
       .Include(x => x.ProductionEmployee)
       .ToListAsync();
        }
    }
}

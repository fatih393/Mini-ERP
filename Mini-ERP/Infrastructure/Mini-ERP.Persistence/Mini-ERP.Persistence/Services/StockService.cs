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
    public class StockService : IStockService
    {
        readonly IStockWriteRepository _stockWriteRepository;
        readonly IStockReadRepository _stockReadRepository;

        public StockService(IStockWriteRepository stockWriteRepository, IStockReadRepository stockReadRepository)
        {
            _stockWriteRepository = stockWriteRepository;
            _stockReadRepository = stockReadRepository;
        }

        public async Task<bool> AddStockAsync(ProductName ProductName, decimal Quantity, Unit Unit, int ReferenceId, ReferenceType referenceType, DateTime LastUpdated)
        {
            try
            {
                var newStock = new Stock
                {
                    ProductName = ProductName,
                    Quantity = Quantity,
                    Unit = Unit,
                    ReferenceId = ReferenceId,
                    ReferenceType = referenceType,
                    LastUpdated = DateTime.Now,

                };
                await _stockWriteRepository.AddAsync(newStock);
                await _stockWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            try
            {
               return await _stockReadRepository.GetAll(false).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<decimal> GetQuantityStockAsync(ProductName productName)
        {
            try
            {
                return await _stockReadRepository
     .GetWhere(x => x.ProductName == productName)
     .OrderByDescending(x => x.LastUpdated)
     .Select(x => x.Quantity)
     .FirstOrDefaultAsync();
            }
            catch (Exception ex) {
                throw;
            }
            }
          
        
    }
}

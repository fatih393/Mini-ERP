using Microsoft.EntityFrameworkCore;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.DTOs.GetProduction;
using Mini_ERP.Application.Repostories;
using Mini_ERP.Domain.Entities;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence.Services
{
    public class ProductionService : IProductionService
    {
        readonly IProductionReadRepository _productionReadRepository;
        readonly IProductionWriteRepository _productionWriteRepository;
        readonly IQRCodeService _qrCodeService;
        public ProductionService(IProductionReadRepository productionReadRepository, IProductionWriteRepository productionWriteRepository, IQRCodeService qrCodeService)
        {
            _productionReadRepository = productionReadRepository;
            _productionWriteRepository = productionWriteRepository;
            _qrCodeService = qrCodeService;
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

        public async Task<List<ProductionDto>> GetProductionAsync()
        {
            return await _productionReadRepository.GetAll()
      .Include(x => x.ProductionEmployee)
      .Select(p => new ProductionDto
      {
          ProductName = p.ProductName.ToString(),
          ProductionEmployeeId = p.ProductionEmployeeId,
          ProductionEmployeeName = p.ProductionEmployee.Name,
          OutputQuantity = p.OutputQuantity,
          Unit = p.Unit.ToString(),
          ConsumedMilkQuantity = p.ConsumedMilkQuantity,
          BatchCode = p.BatchCode,
          ProductDate = p.ProductDate
      })
      .ToListAsync();
        }

        public async Task<bool> UpdateProductionAsync(int id, decimal OutputQuantity, decimal ConsumedMilkQuantity, Unit Unit)
        {
            try
            {
                Production production = await _productionReadRepository.GetByIdAsync(id);
                production.OutputQuantity = OutputQuantity;
                production.ConsumedMilkQuantity = ConsumedMilkQuantity;
                production.Unit = Unit;
                await _productionWriteRepository.SaveAsync();
                return true;
            }
            catch
            {
                return false;
            }
           
        }


        public async Task<string> GenarateBatchCode(int ProductionId)
        {
            Production production = await _productionReadRepository.GetByIdAsync(ProductionId);
            if (production == null)
                throw new Exception("Kayıt bulunamadı");
            var raw = $"{production.Id}-{production.ProductName}-{production.OutputQuantity}-{production.ConsumedMilkQuantity}-{production.Unit}-{production.ProductDate:yyyyMMddHHmmss}";

            var hash = Convert.ToBase64String(
                System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(raw))
            );

            var batchCode = $"PRD-{production.Id}-{hash.Substring(0, 10)}";

            return batchCode;

        }

        public async Task<bool> UpdateProducitonBatchCodeByIdAsync(int id, string batchCode)
        {
            try
            {
                Production production = await _productionReadRepository.GetByIdAsync(id);
            production.BatchCode = batchCode;
            await _productionWriteRepository.SaveAsync();
            return true;
            }
            catch { return false; }
            
        }
        public async Task<string> GetByIdProductionAsync(int id)
        {

            Production production = await _productionReadRepository.GetByIdAsync(id, false);
            return production.BatchCode;
        }

        public async Task<byte[]> GenarateQrCode(string batchCode)
        {
            try
            {
                return _qrCodeService.GenerateQRCode(batchCode);
            }
            catch
            {
                throw;
            }
        }
    }
}

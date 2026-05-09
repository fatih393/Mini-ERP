using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.MilkCollection.CreateMilkCollection;
using Mini_ERP.Domain.Entities;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Production.CreateProduction
{
    public class CreateProductionCommandHandler : IRequestHandler<CreateProductionCommandRequest, DataResult<CreateProductionCommandResponse>>
    {
        readonly IProductionService _service;
        readonly ILogger<Domain.Entities.Production> _logger;
        readonly IStockService _stockService;

        public CreateProductionCommandHandler(IProductionService service, ILogger<Domain.Entities.Production> logger, IStockService stockService)
        {
            _service = service;
            _logger = logger;
            _stockService = stockService;
        }

        public async Task<DataResult<CreateProductionCommandResponse>> Handle(CreateProductionCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
             
              var newProductionId =   await _service.AddProductionAsync(request.ProductName, request.ProductionEmployeeId, request.OutputQuantity, request.Unit, request.ConsumedMilkQuantity, request.ProductDate);
               var batchCode = await _service.GenarateBatchCode(newProductionId);
                await _service.UpdateProducitonBatchCodeByIdAsync(newProductionId, batchCode);
                try
                {
                    if(request.ProductName == ProductName.Yogurt)
                    {
                        var milkQuantity = await _stockService.GetQuantityStockAsync(ProductName.Milk);
                        await _stockService.AddStockAsync(ProductName.Milk, milkQuantity - request.ConsumedMilkQuantity, Domain.Enums.Unit.Liter, newProductionId, ReferenceType.Production, DateTime.Now);
                        var yogurtQuantity = await _stockService.GetQuantityStockAsync(ProductName.Yogurt);
                        await _stockService.AddStockAsync(ProductName.Yogurt, request.OutputQuantity + yogurtQuantity, request.Unit, newProductionId, ReferenceType.Production, DateTime.Now);
                    }
                    else if(request.ProductName == ProductName.Ayran)
                    {
                        var yogurtQuantity = await _stockService.GetQuantityStockAsync(ProductName.Yogurt);
                        await _stockService.AddStockAsync(ProductName.Yogurt, yogurtQuantity - request.ConsumedMilkQuantity, Domain.Enums.Unit.Pallet, newProductionId , ReferenceType.Production, DateTime.Now);
                        var ayranQuantity = await _stockService.GetQuantityStockAsync(ProductName.Ayran);
                        await _stockService.AddStockAsync(ProductName.Ayran, request.OutputQuantity + ayranQuantity, request.Unit, newProductionId, ReferenceType.Production, DateTime.Now);
                    }
                    else
                    {
                        var milkQuantity = await _stockService.GetQuantityStockAsync(ProductName.Milk);
                        var cheeseQuantity = await _stockService.GetQuantityStockAsync(ProductName.Cheese);
                        await _stockService.AddStockAsync(ProductName.Milk, milkQuantity - request.ConsumedMilkQuantity, Domain.Enums.Unit.Liter, newProductionId, ReferenceType.Production, DateTime.Now);
                        await _stockService.AddStockAsync(ProductName.Cheese, request.OutputQuantity + cheeseQuantity, request.Unit, newProductionId, ReferenceType.Production, DateTime.Now);
                    }
                       
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Stock kaydı sırasında bir hata oluştu. Hata kodu = ");
                    return new ErrorDataResult<CreateProductionCommandResponse>("stock kaydı sırasında bir hata oluştu. Hata kodu = " + ex);
                }
                _logger.LogInformation("Production kaydı başarılı");
                return new SuccessDataResult<CreateProductionCommandResponse>( new CreateProductionCommandResponse{BatchCode = batchCode },"Production kaydı başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "production kaydı sırasında bir hata oluştu.  ");
                return new ErrorDataResult<CreateProductionCommandResponse>("Production kaydı sırasında bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

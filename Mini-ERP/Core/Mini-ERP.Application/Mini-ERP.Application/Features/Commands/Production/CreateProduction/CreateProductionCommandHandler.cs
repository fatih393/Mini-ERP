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
             
              var newProduction =   await _service.AddProductionAsync(request.ProductName, request.ProductionEmployeeId, request.OutputQuantity-1, request.Unit, request.ConsumedMilkQuantity, request.ProductDate);
               
                try
                {
                    var milkQuantity = await _stockService.GetQuantityStockAsync();
                    await _stockService.AddStockAsync(ProductName.Milk, milkQuantity - request.ConsumedMilkQuantity, Domain.Enums.Unit.Liter, newProduction, ReferenceType.Production, DateTime.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Stock kaydı sırasında bir hata oluştu. Hata kodu = ");
                    return new ErrorDataResult<CreateProductionCommandResponse>("stock kaydı sırasında bir hata oluştu. Hata kodu = " + ex);
                }
                _logger.LogInformation("Production kaydı başarılı");
                return new SuccessDataResult<CreateProductionCommandResponse>(null, "Production kaydı başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "production kaydı sırasında bir hata oluştu.  ");
                return new ErrorDataResult<CreateProductionCommandResponse>("Production kaydı sırasında bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

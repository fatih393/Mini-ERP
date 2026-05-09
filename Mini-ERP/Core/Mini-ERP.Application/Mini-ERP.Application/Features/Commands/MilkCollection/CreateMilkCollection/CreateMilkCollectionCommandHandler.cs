using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Employee.UpdateEmployee;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.MilkCollection.CreateMilkCollection
{
    public class CreateMilkCollectionCommandHandler : IRequestHandler<CreateMilkCollectionCommandRequest, DataResult<CreateMilkCollectionCommandResponse>>
    {
        readonly IMilkCollectionService _milkCollectionService;
       readonly ILogger<CreateMilkCollectionCommandHandler> _logger;
        readonly IStockService _stockService;
        
        public CreateMilkCollectionCommandHandler(IMilkCollectionService milkCollectionService, ILogger<CreateMilkCollectionCommandHandler> logger, IStockService stockService)
        {
            _milkCollectionService = milkCollectionService;
            _logger = logger;
            _stockService = stockService;
        }

        public async Task<DataResult<CreateMilkCollectionCommandResponse>> Handle(CreateMilkCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
               var milkCollection = await _milkCollectionService.AddMilkCollectionAsync(request.Quantity, request.FatRate, request.ProteinRate, request.Note, request.Status, request.SupplierId,
                    request.CollectorEmployeeId, request.QualityEmployeeId);
                try
                {
                   if(request.Status == true)
                    {
                        var milkQuantity = await _stockService.GetQuantityStockAsync(ProductName.Milk);
                        await _stockService.AddStockAsync(ProductName.Milk, request.Quantity + milkQuantity, Domain.Enums.Unit.Liter, milkCollection, ReferenceType.MilkCollection, DateTime.Now);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Stock kaydı sırasında bir hata oluştu. Hata kodu = ");
                    return new ErrorDataResult<CreateMilkCollectionCommandResponse>("stock kaydı sırasında bir hata oluştu. Hata kodu = " + ex);
                }
                _logger.LogInformation("MilkCollection kaydı başarılı");
                return new SuccessDataResult<CreateMilkCollectionCommandResponse>(null, "MilkCollection kaydı başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogError("MilkCollection kaydı sırasında bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<CreateMilkCollectionCommandResponse>("MilkCollection kaydı sırasında bir hata oluştu. Hata kodu = "+ex);
            }
        }
    }
}

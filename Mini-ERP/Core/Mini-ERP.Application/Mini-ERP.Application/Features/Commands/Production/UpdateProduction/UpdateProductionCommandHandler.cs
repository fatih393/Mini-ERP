using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Supplier.UpdateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Production.UpdateProduction
{
    public class UpdateProductionCommandHandler : IRequestHandler<UpdateProductionCommandRequest, DataResult<UpdateProductionCommandResponse>>
    {
        readonly ILogger<Domain.Entities.Production> _logger;
        readonly IProductionService _service;

        public UpdateProductionCommandHandler(ILogger<Domain.Entities.Production> logger, IProductionService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<DataResult<UpdateProductionCommandResponse>> Handle(UpdateProductionCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _service.UpdateProductionAsync(request.Id, request.OutputQuantity, request.ConsumedMilkQuantity, request.Unit);
                _logger.LogInformation("Kayıt güncellendi");
                return new SuccessDataResult<UpdateProductionCommandResponse>(null, "Kayıt güncellendi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Kayıt bulunamadı veya silinemedi ");
                return new ErrorDataResult<UpdateProductionCommandResponse>("Kayıt bulunamadı veya silinemedi " + ex);
            }
        }
    }
}

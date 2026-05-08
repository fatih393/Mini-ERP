using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.Production.GetProduction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Production.GetProductionQrCode
{
    public class GetProductionQrCodeHandler : IRequestHandler<GetProductionQrCodeRequest, DataResult<GetProductionQrCodeResponse>>
    {
        readonly ILogger<Domain.Entities.Production> _logger;
        readonly IProductionService _service;

        public GetProductionQrCodeHandler(ILogger<Domain.Entities.Production> logger, IProductionService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<DataResult<GetProductionQrCodeResponse>> Handle(GetProductionQrCodeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var batchCode = await _service.GetByIdProductionAsync(request.Id);
                byte[] byteGraphic = await _service.GenarateQrCode(batchCode);
                return new SuccessDataResult<GetProductionQrCodeResponse>(new GetProductionQrCodeResponse { byteGraphic = byteGraphic }, "Qr code oluşumu başarılı");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Qr Code oluşumu esnasında bir hata oluştu");
                return new ErrorDataResult<GetProductionQrCodeResponse>(" Qr Code oluşumu esnasında bir hata oluştu " + ex);
            }
        }
    }
}

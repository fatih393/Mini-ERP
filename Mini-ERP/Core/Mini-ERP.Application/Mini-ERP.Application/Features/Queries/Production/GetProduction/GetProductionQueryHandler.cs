using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.DTOs.GetProduction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Production.GetProduction
{
    public class GetProductionQueryHandler : IRequestHandler<GetProductionQueryRequest, DataResult<GetProductionQueryResponse>>
    {
        readonly IProductionService _service;
        readonly ILogger<Domain.Entities.Production> _logger;

        public GetProductionQueryHandler(IProductionService service, ILogger<Domain.Entities.Production> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<DataResult<GetProductionQueryResponse>> Handle(GetProductionQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
            List<ProductionDto> productions = await _service.GetProductionAsync();
            if(productions != null && productions.Any())
            {
                _logger.LogInformation("Productions listeleme başarılı");
                return new SuccessDataResult<GetProductionQueryResponse>(new GetProductionQueryResponse { productions = productions }, "Productions listeleme başarılı");
            }
            _logger.LogWarning("Liste boş");
            return new ErrorDataResult<GetProductionQueryResponse>("Liste boş");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Listeleme esnasında bir hata oluştu");
                return new ErrorDataResult<GetProductionQueryResponse>("Listeleme sırasında bir hata oluştu. Hata kodu= "+ex);
            }
            
        }
    }
}

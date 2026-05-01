using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdCollectorEmployeeId;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdMilkCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdQualityEmployeeId
{
    public class GetByIdQualityEmployeeIdHandler : IRequestHandler<GetByIdQualityEmployeeIdRequest, DataResult<GetByIdQualityEmployeeIdResponse>>
    {
        readonly IMilkCollectionService _service;
       readonly ILogger<GetByIdQualityEmployeeIdHandler> _logger;

        public GetByIdQualityEmployeeIdHandler(IMilkCollectionService service, ILogger<GetByIdQualityEmployeeIdHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<DataResult<GetByIdQualityEmployeeIdResponse>> Handle(GetByIdQualityEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var control = await _service.GetQualityEmployeeId(request.Id);
                if (control != null)
                   {
                    _logger.LogInformation("MilkCollection qualtyemployee id listeleme başarılı");
                    return new SuccessDataResult<GetByIdQualityEmployeeIdResponse>(new GetByIdQualityEmployeeIdResponse { milkCollection = control }, "MilkCollection qualtyemployee id listeleme başarılı");
                }
                return new ErrorDataResult<GetByIdQualityEmployeeIdResponse>("Data boş");
                        
                        }
            catch (Exception ex)
            {
                _logger.LogError("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<GetByIdQualityEmployeeIdResponse>("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

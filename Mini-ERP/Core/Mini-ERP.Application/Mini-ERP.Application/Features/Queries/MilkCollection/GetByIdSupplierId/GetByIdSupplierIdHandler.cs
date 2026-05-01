using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdQualityEmployeeId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdSupplierId
{
    public class GetByIdSupplierIdHandler : IRequestHandler<GetByIdSupplierIdRequest, DataResult<GetByIdSupplierIdResponse>>
    {
        readonly IMilkCollectionService _service;
       readonly ILogger<GetByIdSupplierIdHandler> _logger;

        public GetByIdSupplierIdHandler(IMilkCollectionService service, ILogger<GetByIdSupplierIdHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<DataResult<GetByIdSupplierIdResponse>> Handle(GetByIdSupplierIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var control = await _service.GetSupplierId(request.Id);
                if (control != null)
                    {
                    _logger.LogInformation("MilkCollection supplier listeleme başarılı");
                    return new SuccessDataResult<GetByIdSupplierIdResponse>(new GetByIdSupplierIdResponse { milkCollections = control }, "MilkCollection supplier listeleme başarılı"); 
                }
                _logger.LogError("Data boş");
                return new ErrorDataResult<GetByIdSupplierIdResponse>("Data boş");

            }
            catch (Exception ex)
            {
                _logger.LogError("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<GetByIdSupplierIdResponse>("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

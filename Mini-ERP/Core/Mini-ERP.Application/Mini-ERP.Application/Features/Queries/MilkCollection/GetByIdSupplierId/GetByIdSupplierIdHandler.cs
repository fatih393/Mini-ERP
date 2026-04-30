using MediatR;
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

        public GetByIdSupplierIdHandler(IMilkCollectionService service)
        {
            _service = service;
        }

        public async Task<DataResult<GetByIdSupplierIdResponse>> Handle(GetByIdSupplierIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var control = await _service.GetSupplierId(request.Id);
                if (control != null)
                    return new SuccessDataResult<GetByIdSupplierIdResponse>(new GetByIdSupplierIdResponse { milkCollections = control }, "MilkCollection supplier listeleme başarılı");
                return new ErrorDataResult<GetByIdSupplierIdResponse>("Data boş");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetByIdSupplierIdResponse>("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

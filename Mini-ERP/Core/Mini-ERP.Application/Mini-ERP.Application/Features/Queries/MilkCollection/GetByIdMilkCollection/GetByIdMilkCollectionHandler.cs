using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdQualityEmployeeId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdMilkCollection
{
    public class GetByIdMilkCollectionHandler : IRequestHandler<GetByIdMilkCollectionRequest, DataResult<GetByIdMilkCollectionResponse>>
    {
        readonly IMilkCollectionService _service;

        public GetByIdMilkCollectionHandler(IMilkCollectionService service)
        {
            _service = service;
        }

        public async Task<DataResult<GetByIdMilkCollectionResponse>> Handle(GetByIdMilkCollectionRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var control = await _service.GetByIdMilkCollection(request.Id);
                if (control != null)
                    return new SuccessDataResult<GetByIdMilkCollectionResponse>(new GetByIdMilkCollectionResponse { milkCollection = control }, "MilkCollection id listeleme başarılı");
                return new ErrorDataResult<GetByIdMilkCollectionResponse>("Data boş");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetByIdMilkCollectionResponse>("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdCollectorEmployeeId;
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

        public GetByIdQualityEmployeeIdHandler(IMilkCollectionService service)
        {
            _service = service;
        }

        public async Task<DataResult<GetByIdQualityEmployeeIdResponse>> Handle(GetByIdQualityEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var control = await _service.GetQualityEmployeeId(request.Id);
                if (control != null)
                    return new SuccessDataResult<GetByIdQualityEmployeeIdResponse>(new GetByIdQualityEmployeeIdResponse { milkCollection = control }, "MilkCollection qualtyemployee id listeleme başarılı");
                return new ErrorDataResult<GetByIdQualityEmployeeIdResponse>("Data boş");
                        
                        }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetByIdQualityEmployeeIdResponse>("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex);
            }
        }
    }
}

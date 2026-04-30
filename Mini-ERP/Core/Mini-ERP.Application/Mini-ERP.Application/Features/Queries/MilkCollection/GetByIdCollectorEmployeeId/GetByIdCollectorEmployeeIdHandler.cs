using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdCollectorEmployeeId
{
    public class GetByIdCollectorEmployeeIdHandler : IRequestHandler<GetByIdCollectorEmployeeIdRequest, DataResult<GetByIdCollectorEmployeeIdResponse>>
    {
        readonly IMilkCollectionService _service;

        public GetByIdCollectorEmployeeIdHandler(IMilkCollectionService service)
        {
            _service = service;
        }

        public async Task<DataResult<GetByIdCollectorEmployeeIdResponse>> Handle(GetByIdCollectorEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var control = await _service.GetCollectorEmployeeId(request.Id);
                if (control != null)
                    return new SuccessDataResult<GetByIdCollectorEmployeeIdResponse>(new GetByIdCollectorEmployeeIdResponse { milkCollection = control }, "MilkCollection id listeleme başarılı");
                return new ErrorDataResult<GetByIdCollectorEmployeeIdResponse>("Data boş");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetByIdCollectorEmployeeIdResponse>("Listeleme sırasında bir hata oluştu. Hata kodu = " + ex); 
            }
        }
    }
}

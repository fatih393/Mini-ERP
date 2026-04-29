using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.DTOs.GetMilkCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetMilkCollection
{
    public class GetMilkCollectionHandler : IRequestHandler<GetMilkCollectionRequest, DataResult<GetMilkCollectionResponse>>
    {
        readonly IMilkCollectionService _milkcollectionservice;

        public GetMilkCollectionHandler(IMilkCollectionService milkcollectionservice)
        {
            _milkcollectionservice = milkcollectionservice;
        }

        public async Task<DataResult<GetMilkCollectionResponse>> Handle(GetMilkCollectionRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<MilkCollectionDto> milkCollections = await _milkcollectionservice.GetMilkCollectionAsync();
                if (milkCollections != null)
                    return new SuccessDataResult<GetMilkCollectionResponse>(new GetMilkCollectionResponse { milkCollections = milkCollections }, "MilkCollection listeleme başarılı");
                return new ErrorDataResult<GetMilkCollectionResponse>("MilkCollection listelsi boş");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetMilkCollectionResponse>("MilkCollection listlenirken bir hata oluştu. Hata kodu = "+ex);
            }
            }
    }
}

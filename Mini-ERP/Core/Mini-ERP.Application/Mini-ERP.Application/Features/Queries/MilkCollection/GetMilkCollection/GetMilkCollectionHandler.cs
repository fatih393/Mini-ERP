using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.DTOs.GetMilkCollection;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdSupplierId;
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
       readonly ILogger<GetMilkCollectionHandler> _logger;


        public GetMilkCollectionHandler(IMilkCollectionService milkcollectionservice, ILogger<GetMilkCollectionHandler> logger)
        {
            _milkcollectionservice = milkcollectionservice;
            _logger = logger;
        }

        public async Task<DataResult<GetMilkCollectionResponse>> Handle(GetMilkCollectionRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<MilkCollectionDto> milkCollections = await _milkcollectionservice.GetMilkCollectionAsync();
                if (milkCollections != null)
                   {
                    _logger.LogInformation("MilkCollection listeleme başarılı");
                    return new SuccessDataResult<GetMilkCollectionResponse>(new GetMilkCollectionResponse { milkCollections = milkCollections }, "MilkCollection listeleme başarılı"); 
                }
                _logger.LogError("MilkCollection listelsi boş");
                return new ErrorDataResult<GetMilkCollectionResponse>("MilkCollection listelsi boş");
            }
            catch (Exception ex)
            {
                _logger.LogError("MilkCollection listlenirken bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<GetMilkCollectionResponse>("MilkCollection listlenirken bir hata oluştu. Hata kodu = "+ex);
            }
            }
    }
}

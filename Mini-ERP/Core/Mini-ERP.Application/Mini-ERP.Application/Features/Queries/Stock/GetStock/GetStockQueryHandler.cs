using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.Supplier.GetSupplier;
using Mini_ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Stock.GetStock
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQueryRequest, DataResult<GetStockQueryResponse>>
    {
        readonly IStockService _stockService;
        readonly ILogger<Domain.Entities.Stock> _logger;

        public GetStockQueryHandler(IStockService stockService, ILogger<Domain.Entities.Stock> logger)
        {
            _stockService = stockService;
            _logger = logger;
        }

        public async Task<DataResult<GetStockQueryResponse>> Handle(GetStockQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
               List<Domain.Entities.Stock> stocks = await _stockService.GetAllAsync();
                if(stocks != null)
                {
                    _logger.LogInformation("Listeleme başarılı...");
                    return new SuccessDataResult<GetStockQueryResponse>(
                        new GetStockQueryResponse { stock = stocks }, "Listeleme başarılı..."

                        );

                }
                _logger.LogError("Stock listesi boş");
                return new ErrorDataResult<GetStockQueryResponse>("Stock listesi boş");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex ,"Stock listelenirken bir hata oluştu. Hata kodu");
                return new ErrorDataResult<GetStockQueryResponse>("Stock listelenirken bir hata oluştu. Hata kodu"+ ex);
            }
        }
    }
}

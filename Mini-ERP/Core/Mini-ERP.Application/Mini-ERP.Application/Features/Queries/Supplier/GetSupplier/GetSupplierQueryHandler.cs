using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Queries.MilkCollection.GetMilkCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Supplier.GetSupplier
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQueryRequest, DataResult<GetSupplierQueryResponse>>
    {
        readonly ISupplierService _supplierService;
       readonly ILogger<GetSupplierQueryHandler> _logger;
        public GetSupplierQueryHandler(ISupplierService supplierService, ILogger<GetSupplierQueryHandler> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        public async Task<DataResult<GetSupplierQueryResponse>> Handle(GetSupplierQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                 List<Domain.Entities.Supplier> suppliers = await _supplierService.GetSuppliersAsync();
                if (suppliers != null)
                {
                    _logger.LogInformation("Listeleme başarılı...");
                return new SuccessDataResult<GetSupplierQueryResponse>(
                    new GetSupplierQueryResponse { supplier = suppliers }, "Listeleme başarılı..."

                    );
                    
                }
                _logger.LogError("Supplier listesi boş");
                return new ErrorDataResult<GetSupplierQueryResponse>("Supplier listesi boş");
            }
            catch (Exception ex)
            {
                _logger.LogError("Bir hata oluştu " + ex);
                return new ErrorDataResult<GetSupplierQueryResponse>("Bir hata oluştu "+ ex);
            }
           
        }
    }
}

using MediatR;
using Mini_ERP.Application.Abstractions.Services;
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

        public GetSupplierQueryHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<DataResult<GetSupplierQueryResponse>> Handle(GetSupplierQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                 List<Domain.Entities.Supplier> suppliers = await _supplierService.GetSuppliersAsync();
                return new SuccessDataResult<GetSupplierQueryResponse>(
                    new GetSupplierQueryResponse { supplier = suppliers }, "Listeleme başarılı..."

                    );
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetSupplierQueryResponse>("Bir hata oluştu "+ ex);
            }
           
        }
    }
}

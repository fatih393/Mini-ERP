using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Supplier.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommandRequest, DataResult<UpdateSupplierCommandResponse>>
    {
        readonly ISupplierService _supplierService;

        public UpdateSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<DataResult<UpdateSupplierCommandResponse>> Handle(UpdateSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _supplierService.UpdateSupplierAsync(
                    request.Id,
                    request.SupplierName,
                    request.Phone,
                    request.Address,
                    request.Location

                    );
                return new SuccessDataResult<UpdateSupplierCommandResponse>(null, "Kayıt güncellendi");
            }
            catch ( Exception ex )
            {
                return new ErrorDataResult<UpdateSupplierCommandResponse>("Kayıt bulunamadı veya silinemedi "+ ex);
            }
        }
    }
}

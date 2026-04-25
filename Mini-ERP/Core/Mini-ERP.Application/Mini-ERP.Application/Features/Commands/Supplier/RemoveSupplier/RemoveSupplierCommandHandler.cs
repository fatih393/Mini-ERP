using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Supplier.RemoveSupplier
{
    public class RemoveSupplierCommandHandler : IRequestHandler<RemoveSupplierCommandRequest, DataResult<RemoveSupplierCommandResponse>>
    {
        readonly ISupplierService _supplierService;

        public RemoveSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<DataResult<RemoveSupplierCommandResponse>> Handle(RemoveSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _supplierService.RemoveSupplierAsync(request.Id);

                if (result)
                    return new ErrorDataResult<RemoveSupplierCommandResponse>("Kayıt bulunamadı");

                return new SuccessDataResult<RemoveSupplierCommandResponse>(null, "Kayıt silindi");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<RemoveSupplierCommandResponse>("Silme işlemi sırasında bir hata oluştu "+ ex);
            }
        }
    }
}

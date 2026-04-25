using MediatR;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Supplier.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommandRequest, DataResult<CreateSupplierCommandResponse>>
    {
        readonly ISupplierService _supplierService;

        public CreateSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<DataResult<CreateSupplierCommandResponse>> Handle(CreateSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            bool control = await _supplierService.AddSupplierAsync(request.SupplierName, request.Phone, request.Address, request.Location);
            if (control)
                return new SuccessDataResult<CreateSupplierCommandResponse>(null, "Supplier kaydı başarılı");
            return new ErrorDataResult<CreateSupplierCommandResponse>();
        }
    }
}

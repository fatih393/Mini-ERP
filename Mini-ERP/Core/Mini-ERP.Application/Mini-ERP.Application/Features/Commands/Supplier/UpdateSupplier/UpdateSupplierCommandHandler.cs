using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Supplier.RemoveSupplier;
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
        readonly ILogger<UpdateSupplierCommandHandler> _logger;

        public UpdateSupplierCommandHandler(ISupplierService supplierService, ILogger<UpdateSupplierCommandHandler> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
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
                _logger.LogInformation("Kayıt güncellendi");
                return new SuccessDataResult<UpdateSupplierCommandResponse>(null, "Kayıt güncellendi");
            }
            catch ( Exception ex )
            {
                _logger.LogError("Kayıt bulunamadı veya silinemedi " + ex);
                return new ErrorDataResult<UpdateSupplierCommandResponse>("Kayıt bulunamadı veya silinemedi "+ ex);
            }
        }
    }
}

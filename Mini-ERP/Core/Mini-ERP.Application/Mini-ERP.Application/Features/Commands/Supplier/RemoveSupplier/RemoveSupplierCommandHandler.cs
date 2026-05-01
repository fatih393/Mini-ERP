using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Supplier.CreateSupplier;
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
        readonly ILogger<RemoveSupplierCommandHandler> _logger;

        public RemoveSupplierCommandHandler(ISupplierService supplierService, ILogger<RemoveSupplierCommandHandler> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        public async Task<DataResult<RemoveSupplierCommandResponse>> Handle(RemoveSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _supplierService.RemoveSupplierAsync(request.Id);

                if (result)
                   {
                    _logger.LogWarning("Kayıt bulunamadı");
                    return new ErrorDataResult<RemoveSupplierCommandResponse>("Kayıt bulunamadı"); 
                }
                _logger.LogInformation("Kayıt silindi");
                return new SuccessDataResult<RemoveSupplierCommandResponse>(null, "Kayıt silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError("Silme işlemi sırasında bir hata oluştu " + ex);
                return new ErrorDataResult<RemoveSupplierCommandResponse>("Silme işlemi sırasında bir hata oluştu "+ ex);
            }
        }
    }
}

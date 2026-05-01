using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.MilkCollection.CreateMilkCollection;
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
        readonly ILogger<CreateSupplierCommandHandler> _logger;
        public CreateSupplierCommandHandler(ISupplierService supplierService, ILogger<CreateSupplierCommandHandler> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        public async Task<DataResult<CreateSupplierCommandResponse>> Handle(CreateSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
            bool control = await _supplierService.AddSupplierAsync(request.SupplierName, request.Phone, request.Address, request.Location);
           
                _logger.LogInformation("Supplier kaydı başarılı");
                return new SuccessDataResult<CreateSupplierCommandResponse>(null, "Supplier kaydı başarılı"); 
            
            }
            catch (Exception ex)
            {
                _logger.LogError("Supplier kaydı sırasında bir hata oluştu" + ex);
                return new ErrorDataResult<CreateSupplierCommandResponse>("Supplier kaydı sırasında bir hata oluştu"+ex);
            }
           
            
        }
    }
}

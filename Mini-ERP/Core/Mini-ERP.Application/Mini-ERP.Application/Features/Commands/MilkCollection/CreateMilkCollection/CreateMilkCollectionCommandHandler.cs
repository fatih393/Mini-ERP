using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Features.Commands.Employee.UpdateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.MilkCollection.CreateMilkCollection
{
    public class CreateMilkCollectionCommandHandler : IRequestHandler<CreateMilkCollectionCommandRequest, DataResult<CreateMilkCollectionCommandResponse>>
    {
        readonly IMilkCollectionService _milkCollectionService;
       readonly ILogger<CreateMilkCollectionCommandHandler> _logger;
        public CreateMilkCollectionCommandHandler(IMilkCollectionService milkCollectionService, ILogger<CreateMilkCollectionCommandHandler> logger)
        {
            _milkCollectionService = milkCollectionService;
            _logger = logger;
        }

        public async Task<DataResult<CreateMilkCollectionCommandResponse>> Handle(CreateMilkCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _milkCollectionService.AddMilkCollectionAsync(request.Quantity, request.FatRate, request.ProteinRate, request.Note, request.Status, request.SupplierId,
                    request.CollectorEmployeeId, request.QualityEmployeeId);
                _logger.LogInformation("MilkCollection kaydı başarılı");
                return new SuccessDataResult<CreateMilkCollectionCommandResponse>(null, "MilkCollection kaydı başarılı");

            }
            catch (Exception ex)
            {
                _logger.LogError("MilkCollection kaydı sırasında bir hata oluştu. Hata kodu = " + ex);
                return new ErrorDataResult<CreateMilkCollectionCommandResponse>("MilkCollection kaydı sırasında bir hata oluştu. Hata kodu = "+ex);
            }
        }
    }
}

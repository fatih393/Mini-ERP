using MediatR;
using Mini_ERP.Application.Abstractions.Services;
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

        public CreateMilkCollectionCommandHandler(IMilkCollectionService milkCollectionService)
        {
            _milkCollectionService = milkCollectionService;
        }

        public async Task<DataResult<CreateMilkCollectionCommandResponse>> Handle(CreateMilkCollectionCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _milkCollectionService.AddMilkCollectionAsync(request.Quantity, request.FatRate, request.ProteinRate, request.Note, request.Status, request.SupplierId,
                    request.CollectorEmployeeId, request.QualityEmployeeId);
                return new SuccessDataResult<CreateMilkCollectionCommandResponse>(null, "MilkCollection kaydı başarılı");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CreateMilkCollectionCommandResponse>("MilkCollection kaydı sırasında bir hata oluştu. Hata kodu = "+ex);
            }
        }
    }
}

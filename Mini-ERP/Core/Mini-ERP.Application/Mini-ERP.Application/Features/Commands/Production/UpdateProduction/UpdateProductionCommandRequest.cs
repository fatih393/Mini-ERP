using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Production.UpdateProduction
{
    public class UpdateProductionCommandRequest: IRequest<DataResult<UpdateProductionCommandResponse>>
    {
        public int Id { get; set; }
        public decimal OutputQuantity { get; set; }
        public decimal ConsumedMilkQuantity { get; set; }
        public Domain.Enums.Unit Unit { get; set; }
    }
}

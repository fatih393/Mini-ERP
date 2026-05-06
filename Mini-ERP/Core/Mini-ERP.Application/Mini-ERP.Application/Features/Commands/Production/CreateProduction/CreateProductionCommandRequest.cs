using MediatR;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Production.CreateProduction
{
    public class CreateProductionCommandRequest: IRequest<DataResult<CreateProductionCommandResponse>>
    {
        public ProductName ProductName { get; set; }

        public int ProductionEmployeeId { get; set; }

        public decimal OutputQuantity { get; set; }


        public Domain.Enums.Unit Unit { get; set; }


        public decimal ConsumedMilkQuantity { get; set; }
        public string? BatchCode { get; set; }

        public DateTime ProductDate { get; set; }
    }
}

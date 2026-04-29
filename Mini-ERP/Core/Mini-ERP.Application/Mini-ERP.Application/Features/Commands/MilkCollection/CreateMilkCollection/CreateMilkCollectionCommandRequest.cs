using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.MilkCollection.CreateMilkCollection
{
    public class CreateMilkCollectionCommandRequest: IRequest<DataResult<CreateMilkCollectionCommandResponse>>
    {
       
        public decimal Quantity { get; set; } // litre
        public decimal FatRate { get; set; }
        public decimal ProteinRate { get; set; }
        public string? Note { get; set; }
        public bool Status { get; set; } = true; // kabul red*/
        public int SupplierId { get; set; }
        public int CollectorEmployeeId { get; set; }
        public int QualityEmployeeId { get; set; }
       
       
    }
}

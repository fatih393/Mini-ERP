using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Mini_ERP.Application.Features.Commands.Supplier.CreateSupplier
{
    public class CreateSupplierCommandRequest : IRequest<DataResult<CreateSupplierCommandResponse>>
    {
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}

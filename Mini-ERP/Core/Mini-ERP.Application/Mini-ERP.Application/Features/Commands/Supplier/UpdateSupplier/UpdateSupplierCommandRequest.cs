using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Supplier.UpdateSupplier
{
    public class UpdateSupplierCommandRequest: IRequest<DataResult<UpdateSupplierCommandResponse>>
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}

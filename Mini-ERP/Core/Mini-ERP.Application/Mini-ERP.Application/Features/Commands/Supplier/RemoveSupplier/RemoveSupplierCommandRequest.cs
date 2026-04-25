using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Commands.Supplier.RemoveSupplier
{
    public class RemoveSupplierCommandRequest: IRequest<DataResult<RemoveSupplierCommandResponse>>
    {
        public int Id { get; set; }
    }
}

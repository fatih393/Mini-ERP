using MediatR;
using Mini_ERP.Application.DTOs.GetMilkCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdSupplierId
{
    public class GetByIdSupplierIdRequest: IRequest<DataResult<GetByIdSupplierIdResponse>>
    {
        public int Id { get; set; }
    }
}

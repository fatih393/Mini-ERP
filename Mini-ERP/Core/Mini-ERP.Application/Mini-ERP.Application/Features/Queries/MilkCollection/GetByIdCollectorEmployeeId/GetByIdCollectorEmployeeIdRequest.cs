using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdCollectorEmployeeId
{
    public class GetByIdCollectorEmployeeIdRequest: IRequest<DataResult<GetByIdCollectorEmployeeIdResponse>>
    {
        public int Id { get; set; }
    }
}

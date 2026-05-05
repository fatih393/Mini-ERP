using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Production.GetProduction
{
    public class GetProductionQueryRequest: IRequest<DataResult<GetProductionQueryResponse>>
    {
    }
}

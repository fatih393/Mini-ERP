using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetMilkCollection
{
    public class GetMilkCollectionRequest: IRequest<DataResult<GetMilkCollectionResponse>>
    {
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdQualityEmployeeId
{
    public class GetByIdQualityEmployeeIdRequest: IRequest<DataResult<GetByIdQualityEmployeeIdResponse>>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Production.GetProductionQrCode
{
    public class GetProductionQrCodeRequest: IRequest<DataResult<GetProductionQrCodeResponse>>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Production.GetProduction
{
    public class GetProductionQueryHandler : IRequestHandler<GetProductionQueryRequest, DataResult<GetProductionQueryResponse>>
    {
        readonly IProductionService _service;
        readonly ILogger<Domain.Entities.Production> _logger;

        public GetProductionQueryHandler(IProductionService service, ILogger<Domain.Entities.Production> logger)
        {
            _service = service;
            _logger = logger;
        }

        public Task<DataResult<GetProductionQueryResponse>> Handle(GetProductionQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

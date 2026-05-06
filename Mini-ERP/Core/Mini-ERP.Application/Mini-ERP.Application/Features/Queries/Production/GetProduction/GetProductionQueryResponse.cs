using Mini_ERP.Application.DTOs.GetProduction;
using Mini_ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Production.GetProduction
{
    public class GetProductionQueryResponse
    {
        public List<ProductionDto> productions { get; set; }
    }
}

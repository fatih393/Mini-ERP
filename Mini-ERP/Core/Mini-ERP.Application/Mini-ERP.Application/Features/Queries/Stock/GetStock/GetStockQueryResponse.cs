using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Stock.GetStock
{
    public class GetStockQueryResponse
    {
        public List< Domain.Entities.Stock> stock { get; set; }
    }
}

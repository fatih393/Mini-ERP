using Mini_ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.Supplier.GetSupplier
{
    public class GetSupplierQueryResponse
    {
        public List<Mini_ERP.Domain.Entities.Supplier> supplier {  get; set; }
    }
}

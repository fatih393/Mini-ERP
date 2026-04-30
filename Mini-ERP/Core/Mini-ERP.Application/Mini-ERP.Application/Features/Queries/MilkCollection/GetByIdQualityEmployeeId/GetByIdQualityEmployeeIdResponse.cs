using Mini_ERP.Application.DTOs.GetMilkCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features.Queries.MilkCollection.GetByIdQualityEmployeeId
{
    public class GetByIdQualityEmployeeIdResponse
    {
        public List<MilkCollectionDto> milkCollection { get; set; }
    }
}

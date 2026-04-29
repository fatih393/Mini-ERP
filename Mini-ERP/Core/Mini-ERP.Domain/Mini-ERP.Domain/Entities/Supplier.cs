using Mini_ERP.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Domain.Entities
{
    public class Supplier: BaseEntitiy
    {
        public string Name { get; set; } // name surnname // subliername
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<MilkCollection> MilkCollections { get; set; } 
    }
}

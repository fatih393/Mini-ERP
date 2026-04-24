using Mini_ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Abstractions.Services
{
    public interface ISupplierService
    {
        Task<bool> AddSupplierAsync(string SupplierName, string Phone, string Address, string Location);
        Task<List<Supplier>> GetSuppliersAsync();
        Task<bool> RemoveSupplierAsync(int id);
        Task<bool> UpdateSupplierAsync(int id, string SupplierName, string Phone, string Address, string Location);

    }
}
/*public string Name { get; set; } // name surnname // subliername
public string Phone { get; set; }
public string Address { get; set; }
public string Location { get; set; }
public DateTime CreateDate { get; set; }
public List<MilkCollection> MilkCollections { get; set; }*/
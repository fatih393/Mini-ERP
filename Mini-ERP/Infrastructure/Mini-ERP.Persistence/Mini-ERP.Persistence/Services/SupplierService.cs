using Microsoft.EntityFrameworkCore;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Repostories;
using Mini_ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence.Services
{
    public class SupplierService : ISupplierService
    {

        readonly ISupplierReadRepository _supplierReadRepository;
        readonly ISupplierWriteRepository _supplierWriteRepository;

        public SupplierService(ISupplierReadRepository supplierReadRepository, ISupplierWriteRepository supplierWriteRepository)
        {
            _supplierReadRepository = supplierReadRepository;
            _supplierWriteRepository = supplierWriteRepository;
        }

        public async Task<bool> AddSupplierAsync(string SupplierName, string Phone, string Address, string Location)
        {
            try
            {
                SupplierName = SupplierName.ToLower();
                var suppliername = await _supplierReadRepository.GetWhere(c => c.Name == SupplierName).FirstOrDefaultAsync();
                string supplierName = suppliername?.Name?.ToLower();
                if (supplierName != null)
                    return false;
                var newSupplier = new Supplier
                {
                    Name = SupplierName.ToLower(),
                    Phone = Phone.ToLower(),
                    Address = Address.ToLower(),
                    Location = Location.ToLower(),
                    CreateDate = DateTime.Now,
                };
                await _supplierWriteRepository.AddAsync(newSupplier);
                await _supplierWriteRepository.SaveAsync();
                return true;


            }
            catch (Exception ex) {
                return false;
            }
        }

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            List<Supplier> suppliers = await _supplierReadRepository.GetAll(false).ToListAsync();
            return suppliers;
        }

        public async Task<bool> RemoveSupplierAsync(int id)
        {
            try
            {
                bool control = await _supplierWriteRepository.RemoveAsync(id);
                await _supplierWriteRepository.SaveAsync();
                return control;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public async Task<bool> UpdateSupplierAsync(int id, string SupplierName, string Phone, string Address, string Location)
        {
            try
            {
                Supplier supplier = await _supplierReadRepository.GetByIdAsync(id);
                supplier.Name = SupplierName;
                supplier.Phone = Phone;
                supplier.Address = Address;
                supplier.Location = Location;
                await _supplierWriteRepository.SaveAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

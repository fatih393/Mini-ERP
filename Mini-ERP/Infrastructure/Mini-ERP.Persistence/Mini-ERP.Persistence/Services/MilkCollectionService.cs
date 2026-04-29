using Microsoft.EntityFrameworkCore;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.DTOs.GetMilkCollection;
using Mini_ERP.Application.Repostories;
using Mini_ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence.Services
{
    public class MilkCollectionService : IMilkCollectionService
    {
        readonly IMilkCollectionReadRepository _milkCollectionReadRepository;
        readonly IMilkCollectionWriteRepository _milkCollectionWriteRepository;

        public MilkCollectionService(IMilkCollectionReadRepository milkCollectionReadRepository, IMilkCollectionWriteRepository milkCollectionWriteRepository)
        {
            _milkCollectionReadRepository = milkCollectionReadRepository;
            _milkCollectionWriteRepository = milkCollectionWriteRepository;
        }

        public async Task<bool> AddMilkCollectionAsync(decimal Quantity, decimal FatRate, decimal ProteinRate, string Note, bool Status, int SupplierId, int CollectorEmployeeId, int QualityEmployeeId)
        {
            try
            {
                var newMilkCollection = new MilkCollection
                {
                    Quantity = Quantity,
                    FatRate = FatRate,
                    ProteinRate = ProteinRate,
                    Note = Note,
                    Status = Status,
                    SupplierId = SupplierId,
                    CollectorEmployeeId = CollectorEmployeeId,
                    QualityEmployeeId = QualityEmployeeId,
                    Date = DateTime.Now
                };
                await _milkCollectionWriteRepository.AddAsync(newMilkCollection);
                await _milkCollectionWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<MilkCollectionDto>> GetMilkCollectionAsync()
        {
            return await _milkCollectionReadRepository.GetAll()
    .Include(x => x.Supplier)
    .Include(x => x.CollectorEmployee)
    .Include(x => x.QualityEmployee)
    .Select(x => new MilkCollectionDto
    {
        Id = x.Id,
        Date = x.Date,
        Quantity = x.Quantity,
        FatRate = x.FatRate,
        ProteinRate = x.ProteinRate,
        Note = x.Note,
        Status = x.Status,

      
        SupplierId = x.SupplierId,
        SupplierName = x.Supplier.Name,

        CollectorEmployeeId = x.CollectorEmployeeId,
        CollectorEmployeeName = x.CollectorEmployee.Name,

        QualityEmployeeId = x.QualityEmployeeId,
        QualityEmployeeName = x.QualityEmployee != null ? x.QualityEmployee.Name : null
    }).ToListAsync();
        }

        public async Task<bool> RemoveMilkCollection(int id)
        {
            try
            {
                bool control = await _milkCollectionWriteRepository.RemoveAsync(id);
                await _milkCollectionWriteRepository.SaveAsync();
                return control;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateMilkCollection(int id, decimal Quantity, decimal FatRate, decimal ProteinRate, string Note, bool Status, int SupplierId, int CollectorEmployeeId, int QualityEmployeeId)
        {
            try
            {
                MilkCollection milkCollection = await _milkCollectionReadRepository.GetByIdAsync(id);
                milkCollection.Quantity = Quantity;
                milkCollection.FatRate = FatRate;
                milkCollection.ProteinRate = ProteinRate;
                milkCollection.Note = Note;
                milkCollection.Status = Status;
                milkCollection.SupplierId = SupplierId;
                milkCollection.CollectorEmployeeId = CollectorEmployeeId;
                milkCollection.QualityEmployeeId = QualityEmployeeId;
                await _milkCollectionWriteRepository.SaveAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

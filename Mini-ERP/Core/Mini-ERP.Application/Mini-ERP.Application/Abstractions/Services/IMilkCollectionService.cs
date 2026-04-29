using Mini_ERP.Application.DTOs.GetMilkCollection;
using Mini_ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Abstractions.Services
{
    public interface IMilkCollectionService
    {
        Task<bool> AddMilkCollectionAsync(decimal Quantity, decimal FatRate, decimal ProteinRate, string Note, bool Status, int SupplierId, int CollectorEmployeeId, int QualityEmployeeId);
        Task<List<MilkCollectionDto>> GetMilkCollectionAsync();
        Task<bool> RemoveMilkCollection(int id);
        Task<bool> UpdateMilkCollection(int id, decimal Quantity, decimal FatRate, decimal ProteinRate, string Note, bool Status, int SupplierId, int CollectorEmployeeId, int QualityEmployeeId);
    }
}
/*
         public DateTime Date { get; set; }// datetimenow der geçeriz service icinde
        public decimal Quantity { get; set; } // litre
        public decimal FatRate { get; set; }
        public decimal ProteinRate { get; set; }
        public string? Note { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int CollectorEmployeeId { get; set; }
        public Employee CollectorEmployee { get; set; }

        public int? QualityEmployeeId { get; set; }
        public Employee? QualityEmployee { get; set; }
        public bool Status { get; set; } = true; // kabul red*/
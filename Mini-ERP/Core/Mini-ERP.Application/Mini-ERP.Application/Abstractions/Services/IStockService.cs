using Mini_ERP.Domain.Entities;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Abstractions.Services
{
    public interface IStockService
    {

        Task<bool> AddStockAsync(string ProductName, decimal Quantity, string Unit, int ReferenceId, ReferenceType referenceType, DateTime LastUpdated);
        Task<List<Stock>> GetAllAsync();


    }

 /*   public string ProductName { get; set; }

    public decimal Quantity { get; set; }

    public string Unit { get; set; }

    public int? ReferenceId { get; set; }

    public ReferenceType ReferenceType { get; set; }

    public DateTime LastUpdated { get; set; }*/

}


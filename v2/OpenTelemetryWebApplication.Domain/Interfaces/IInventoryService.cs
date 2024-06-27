using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenTelemetryWebApplication.Domain.Models;

namespace OpenTelemetryWebApplication.Domain.Interfaces
{
    public interface IInventoryService
    {
        Task<Inventory> GetById(int id);
        Task<Inventory> Add(Inventory inventory);
        Task<Inventory> Update(Inventory inventory);
        Task<bool> Remove(Inventory inventory);
        Task<IEnumerable<Inventory>> SearchInventoryForBook(string searchedValue);
    }
}
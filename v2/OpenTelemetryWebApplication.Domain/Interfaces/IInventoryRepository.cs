using OpenTelemetryWebApplication.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenTelemetryWebApplication.Domain.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> SearchInventoryForBook(string bookName);
    }
}
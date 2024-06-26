using OpenTelemetryWebApplication.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenTelemetryWebApplication.Domain.Interfaces
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<List<Order>> GetOrdersByBookId(int bookId);
    }
}

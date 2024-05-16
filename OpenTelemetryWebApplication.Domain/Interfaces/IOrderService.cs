using System;
using OpenTelemetryWebApplication.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenTelemetryWebApplication.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> Add(Order order); 
        Task<Order> Remove(Order order);
    }
}

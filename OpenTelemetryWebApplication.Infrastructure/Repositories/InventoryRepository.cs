using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTelemetryWebApplication.Domain.Interfaces;
using OpenTelemetryWebApplication.Domain.Models;
using OpenTelemetryWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace OpenTelemetryWebApplication.Infrastructure.Repositories
{
    public class InventoryRepository(BookStoreDbContext db) : Repository<Inventory>(db), IInventoryRepository
    {
        public async Task<IEnumerable<Inventory>> SearchInventoryForBook(string bookName)
        {
            return await Db.Inventories.AsNoTracking()
                .Include(b => b.Book)
                .Where(b => b.Book.Name.Contains(bookName))
                .ToListAsync();
        }
    }
}

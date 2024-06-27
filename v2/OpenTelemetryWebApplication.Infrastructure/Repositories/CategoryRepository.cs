using OpenTelemetryWebApplication.Domain.Interfaces;
using OpenTelemetryWebApplication.Domain.Models;
using OpenTelemetryWebApplication.Infrastructure.Context;
using OpenTelemetryWebApplication.Infrastructure.Metrics;
using System.Threading.Tasks;

namespace OpenTelemetryWebApplication.Infrastructure.Repositories
{
    public class CategoryRepository(BookStoreDbContext context,
        BookStoreMetrics meters) : Repository<Category>(context), ICategoryRepository
    {
        public override async Task Add(Category entity)
        {
            await base.Add(entity);
            meters.AddCategory();
            meters.IncreaseTotalCategories();
        }

        public override async Task Update(Category entity)
        {
            await base.Update(entity);
            meters.UpdateCategory();
        }

        public override async Task Remove(Category entity)
        {
            await base.Remove(entity);
            meters.DeleteCategory();
            meters.DecreaseTotalCategories();
        }


    }
}
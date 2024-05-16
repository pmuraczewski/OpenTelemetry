using OpenTelemetryWebApplication.Domain.Interfaces;
using OpenTelemetryWebApplication.Domain.Services;
using OpenTelemetryWebApplication.Infrastructure.Context;
using OpenTelemetryWebApplication.Infrastructure.Metrics;
using OpenTelemetryWebApplication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection RegisterInfrastureDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddScoped<BookStoreDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<BookStoreMetrics>();

            return services;
        }
    }
}
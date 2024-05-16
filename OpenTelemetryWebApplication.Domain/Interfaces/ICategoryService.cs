using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenTelemetryWebApplication.Domain.Models;

namespace OpenTelemetryWebApplication.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<bool> Remove(Category category);
        Task<IEnumerable<Category>> Search(string categoryName);
    }
}
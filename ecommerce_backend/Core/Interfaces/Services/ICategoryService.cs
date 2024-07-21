using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<IReadOnlyList<ProductCategory>> GetCategoriesAsync();
        public Task<ProductCategory?> GetCategoryByIdAsync(int id);
    }
}
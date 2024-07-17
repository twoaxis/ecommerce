using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IBrandService
    {
        public Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
        public Task<ProductBrand?> GetBrandByIdAsync(int id);
    }
}
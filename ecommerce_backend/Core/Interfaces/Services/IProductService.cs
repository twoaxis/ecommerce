using Core.Entities.Product_Entities;
using Core.Specifications.ProductSpecifications;

namespace Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductsWithSpecificationsAsync(ProductSpecificationParameters specParams);
        Task<Product?> GetProductWithSpecificationsAsync(int id);
    }
}
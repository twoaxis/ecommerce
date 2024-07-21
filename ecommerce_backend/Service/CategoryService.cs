using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ProductCategory>> GetCategoriesAsync()
        {
            return await _unitOfWork.Repository<ProductCategory>().GetAllAsync();
        }

        public async Task<ProductCategory?> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Repository<ProductCategory>().GetByIdAsync(id);
        }
    }
}
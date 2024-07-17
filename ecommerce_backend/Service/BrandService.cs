using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Service
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetBrandsAsync()
        {
            return await _unitOfWork.Repository<ProductBrand>().GetAllAsync();
        }

        public async Task<ProductBrand?> GetBrandByIdAsync(int id)
        {
            return await _unitOfWork.Repository<ProductBrand>().GetByIdAsync(id);
        }
    }
}
﻿using Core.Entities.Product_Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Specifications.ProductSpecifications;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Product>> GetProductsWithSpecificationsAsync(ProductSpecificationParameters specParams)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(specParams);
            var products = await _unitOfWork.Repository<Product>().GetAllWithSpecAsync(spec);
            return products;
        }

        public async Task<Product?> GetProductWithSpecificationsAsync(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product = await _unitOfWork.Repository<Product>().GetByIdWithSpecAsync(spec);
            return product;
        }
    }
}
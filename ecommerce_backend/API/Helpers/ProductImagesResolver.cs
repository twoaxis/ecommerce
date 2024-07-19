using API.Dtos;
using AutoMapper;
using Core.Entities.Product_Entities;

namespace DotNetCore_ECommerce.Helpers
{
    public class ProductImagesResolver : IValueResolver<Product, ProductToReturnDto, string[]>
    {
        private readonly IConfiguration _configuration;

        public ProductImagesResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string[] Resolve(Product source, ProductToReturnDto destination, string[] destMember, ResolutionContext context)
        {
            var ImagesPath = new List<string>();

            if (source.Images is not null)
            {
                foreach (var image in source.Images)
                {
                    ImagesPath.Add($"{_configuration["ApiBaseUrl"]}/{image}");
                }
            }

            return ImagesPath.ToArray();
        }
    }
}
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrandToReturnDto>>> GetBrands()
        {
            var brands = await _brandService.GetBrandsAsync();
            var brandsDto = _mapper.Map<IReadOnlyList<ProductBrand>, IReadOnlyList<ProductBrandToReturnDto>>(brands);
            return Ok(brandsDto);
        }    
    }
}
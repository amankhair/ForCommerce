using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Errors;
using Core.Interfaces;
using Core.RequestFeatures;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery]ProductParameters productParameters)
        {
            var specification = new ProductsWithCategoriesAndBrandsSpecification(productParameters);
            var countSpecification = new ProductWithFiltersForCountSpecification(productParameters);
            var totalItems = await _repository.Product.CountAsync(countSpecification);
            var products = await _repository.Product.ListAsync(specification);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>(productParameters.PageIndex, productParameters.PageSize, totalItems, data));
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid productId)
        {
            var specification = new ProductsWithCategoriesAndBrandsSpecification(productId);
            var product =  await _repository.Product.GetEntityWithSpecification(specification);

            if (product == null) 
                return NotFound(new ApiResponse(404));
            
            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Brand>>> GetBrands()
        {
            var brands = await _repository.Brand.ListAllAsync();

            return Ok(brands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _repository.Category.ListAllAsync();

            return Ok(categories);
        }
    }
}
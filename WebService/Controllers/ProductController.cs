using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebService.Models.DTO;

namespace WebService.Controllers
{
    
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {

        private IDataService _dataService;
        private readonly IMapper _mapper;

        public ProductController(IDataService dataService)
        {
            _mapper = _mapper;
            _dataService = dataService;
        }

        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var product = _dataService.GetProduct(id);
            return Ok(product);
        }

        [HttpGet("name/{Name}", Name = nameof(GetProducts))]
        public IActionResult GetProducts(string name)
        {

            var products = _dataService.GetProductByName(name);

            IList<ProductDTO> newProd = products.Select(x => new ProductDTO
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            if (products.Count == 0)
            {
                return NotFound(newProd);
            }

            
           

            return Ok(newProd);
        }

        private ProductDTO CreateProductDto(Product product)
        {
            var dto = _mapper.Map<ProductDTO>(product);
            return dto;
        }
        
        private object CreateResult(IList<Product> products)
        {
            var items = products.Select(CreateProductDto);
            var result = new
            {
                items
            };
            return result;
        }
    }
}
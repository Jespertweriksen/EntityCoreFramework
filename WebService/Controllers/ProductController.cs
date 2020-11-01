using System.Collections.Generic;
using System.Linq;
using Assignment4;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{Name}")]
        public IActionResult GetProducts(IList<Product> products)
        {
            return null;
        }
    }
}
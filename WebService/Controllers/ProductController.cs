using Assignment4;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
            var product = _dataService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
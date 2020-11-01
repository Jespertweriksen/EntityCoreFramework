using Assignment4;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {

        private IDataService _dataService;

        public CategoryController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}", Name = nameof(getCategory))]
        public IActionResult getCategory(int id)
        {
            var categories = _dataService.GetCategory(id);
            return Ok(categories);
        }

    }
}
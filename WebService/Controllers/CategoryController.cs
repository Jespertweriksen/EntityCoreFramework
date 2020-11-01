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
            var category = _dataService.GetCategory(id);
            
            if (category == null)
            {
                //we can return action results
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet]
        public IActionResult getCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }

    }
}
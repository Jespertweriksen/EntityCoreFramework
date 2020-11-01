﻿using Assignment4;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.DTO;

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

        [HttpPost]
        public IActionResult createCategory(CategoryDTO categoryDto)
        {
            _dataService.CreateCategory(categoryDto.Name, categoryDto.Description);
            return Created("", categoryDto);
        }

        [HttpPut("{id}")]
        public IActionResult updateCategory(int id, CategoryDTO updateCategoryDto)
        {
            _dataService.UpdateCategory(id, updateCategoryDto.Name, updateCategoryDto.Description);
            return Ok();
        }
        

    }
}
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Assignment4;
using AutoMapper;
using EFExample;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.DTO;
using AutoMapper;
using Newtonsoft.Json.Linq;
using WebService.Models.DTO;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {

        private IDataService _dataService;
        private readonly IMapper _mapper;

        public CategoryController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
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
            var category = _dataService.CreateCategory(categoryDto.Name, categoryDto.Description);
            
            return Created("", category);
        }

        [HttpPut("{id}")]
        public IActionResult updateCategory(int id, CategoryDTO updateCategoryDto)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            _dataService.UpdateCategory(id, updateCategoryDto.Name, updateCategoryDto.Description);
            return Ok(updateCategoryDto);
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult deleteData(int id)
        {
            var delete = _dataService.DeleteCategory(id);
            if (id < 0)
            {
                return NotFound();
            }
            return Ok(delete);
        }


    }
}
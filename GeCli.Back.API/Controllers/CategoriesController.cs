using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (categories == null)          
                return NotFound("Categories not found");
            
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)           
                return NotFound("Category not found");
            
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CategoryDTO categoryDTO)
        {
            await _categoryService.CreateCategoryAsync(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int? id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
                return BadRequest();

            if (categoryDTO == null)
                return NotFound();

            await _categoryService.UpdateCategoryAsync(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
           await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}

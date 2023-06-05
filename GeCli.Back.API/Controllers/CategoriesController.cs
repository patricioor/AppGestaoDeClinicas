using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryService = categoryService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            if (categories == null)          
                return NotFound("Categories not found");
            
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)           
                return NotFound("Category not found");
            
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryService.CreateCategoryAsync(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return NotFound();


            var category = _categoryService.GetCategoryByIdAsync(id).Result;
            await _categoryService.UpdateCategoryAsync(category);
            return Ok(category);
        }

        [HttpDelete]
        public async Task<ActionResult<Category>> Delete(int id)
        {
           await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}

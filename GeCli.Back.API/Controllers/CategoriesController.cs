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
        public async Task<ActionResult> Get()
        {
            return Ok(await _categoryRepository.GetCategoriesAsync());
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _categoryRepository.GetCategoryByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CategoryDTO categoryDTO)
        {
            var category = await _categoryService.CreateCategoryAsync(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, categoryDTO);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, CategoryDTO categoryDTO)
        //{
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           await _categoryRepository.RemoveCategoryAsync(id);
            return NoContent();
        }
    }
}

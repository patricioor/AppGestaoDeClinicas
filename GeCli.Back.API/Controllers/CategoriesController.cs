using GeCli.Back.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _categoryManager.GetCategoriesAsync());
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _categoryManager.GetCategoryByIdAsync(id));
        }

        //[HttpPost]
        //public async Task<ActionResult> Post(NewCategory newCategory)
        //{
        //    var category = await _categoryRepository.CreateCategoryAsync(newCategory);
        //    return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(Category Category)
        //{
        //    var category = _mapper.Map<Category>(updateCategory);
        //    await _categoryRepository.UpdateCategoryAsync(category);
        //    return Ok(category);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await _categoryRepository.RemoveCategoryAsync(id);
        //    return NoContent();
        //}
    }
}

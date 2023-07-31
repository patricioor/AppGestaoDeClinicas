using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Category;
using GeCli.Back.Shared.ModelView.Suppliers;
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

        /// <summary>
        /// Return all categories registered in the database.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> Get()
        {
            var category = await _categoryManager.GetCategoriesAsync();

            if(category.Any()) return Ok(category);
            return NotFound();
        }

        /// <summary>
        /// Returns a category queried by id.
        /// </summary>
        /// <param name="id" example="1"> Id of category.</param>
        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            var category = await _categoryManager.GetCategoryByIdAsync(id);

            if(category == null) return NotFound();

            return Ok(category);
        }

        /// <summary>
        /// Insert new category
        /// </summary>
        /// <param name="newCategory"></param>
        [HttpPost]
        [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(NewCategory newCategory)
        {
            var category = await _categoryManager.InsertCategoryAsync(newCategory);
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        /// <summary>
        /// Update an existing category.
        /// </summary>
        /// <param name="updateCategory"></param>
        /// <remarks>When modifying a category, it will be permanently changed in the database.</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(UpdateCategory updateCategory)
        {
            var categoryUpdate = await _categoryManager.UpdateCategoryAsync(updateCategory);
            if(categoryUpdate == null) return NotFound();

            return Ok(categoryUpdate);
        }

        /// <summary>
        /// Delete an existing category based on id.
        /// </summary>
        /// <param name="id" example="1">Id of category</param>
        /// <remarks>When deleting a category, it will be permanently removed from the database.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryManager.DeleteCategoryAsync(id);
            if(category == null) return NotFound();

            return NoContent();
        }
    }
}

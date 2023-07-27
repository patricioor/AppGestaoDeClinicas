using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back.Manager.Implementation
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<CategoryView>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryView> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryView> InsertCategoryAsync(NewCategory newCategory)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryView> RemoveCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryView> UpdateCategoryAsync(UpdateCategory updateCategory)
        {
            throw new NotImplementedException();
        }
    }
}

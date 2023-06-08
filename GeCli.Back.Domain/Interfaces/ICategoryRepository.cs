using GeCli.Back.Domain.Entities;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);

        Task<Category> InsertCategoryAsync(Category Category);
        Task<Category> UpdateCategoryAsync(Category Category);
        Task RemoveCategoryAsync(int id);
    }
}

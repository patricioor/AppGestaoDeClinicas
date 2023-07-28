using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> InsertCategoryAsync(Category Category);
        Task<Category> UpdateCategoryAsync(Category Category);
        Task<Category> DeleteCategoryAsync(int id);
    }
}

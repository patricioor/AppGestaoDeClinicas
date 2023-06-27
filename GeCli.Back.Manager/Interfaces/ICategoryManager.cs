using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Manager.Interfaces
{
    public interface ICategoryManager
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);

        //Task<Category> InsertCategoryAsync(Category Category);
        //Task<Category> UpdateCategoryAsync(Category Category);
        //Task RemoveCategoryAsync(int id);
    }
}

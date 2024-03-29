﻿using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back.Manager.Interfaces
{
    public interface ICategoryManager
    {
        Task<ICollection<CategoryView>> GetCategoriesAsync();
        Task<CategoryView> GetCategoryByIdAsync(int id);

        Task<CategoryView> InsertCategoryAsync(NewCategory newCategory);
        Task<CategoryView> UpdateCategoryAsync(UpdateCategory updateCategory);
        Task<CategoryView> DeleteCategoryAsync(int id);
    }
}

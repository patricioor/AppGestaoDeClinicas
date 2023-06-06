using GeCli.Back.Application.DTOs;
using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);

        Task<Category> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<Category> UpdateCategoryAsync(CategoryDTO categoryDTO);
        Task DeleteCategoryAsync(int id);
    }
}

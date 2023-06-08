using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<Category> InsertCategoryAsync(Category category)
        {
            await _categoryContext.Categories.AddAsync(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var categoryFound = await _categoryContext.Categories.FindAsync(category.Id);

            if (categoryFound == null)
                return null;

            _categoryContext.Entry(categoryFound).CurrentValues.SetValues(category);

            await _categoryContext.SaveChangesAsync();
            return categoryFound;
        }

        public async Task RemoveCategoryAsync(int id)
        {
            var categoryFound = await _categoryContext.Categories.FindAsync(id);

            _categoryContext.Remove(categoryFound);
            await _categoryContext.SaveChangesAsync();
        }
    }
}

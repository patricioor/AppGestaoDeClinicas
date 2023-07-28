using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryContext.Categories
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Category> InsertCategoryAsync(Category category)
        {
            await _categoryContext.Categories.AddAsync(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var categoryFound = await _categoryContext.Categories.FirstOrDefaultAsync(p => p.Id == category.Id);
            if (categoryFound == null)
                return null;

            _categoryContext.Entry(categoryFound).CurrentValues.SetValues(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> RemoveCategoryAsync(int id)
        {
            var categoryFound = await _categoryContext.Categories.FindAsync(id);
            if(categoryFound == null) return null;

            var categoryRemoved = _categoryContext.Categories.Remove(categoryFound);
            await _categoryContext.SaveChangesAsync();
            return categoryRemoved.Entity;
        }
    }
}

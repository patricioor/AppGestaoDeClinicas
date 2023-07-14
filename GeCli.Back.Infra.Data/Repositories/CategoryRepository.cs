using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                .FindAsync(id);
        }

        public async Task<Category> InsertCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var categoryFound = await _context.Categories.FindAsync(category.Id);

            if (categoryFound == null)
                return null;

            _context.Entry(categoryFound).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
            return categoryFound;
        }

        public async Task RemoveCategoryAsync(int id)
        {
            await _context.Categories.FindAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}

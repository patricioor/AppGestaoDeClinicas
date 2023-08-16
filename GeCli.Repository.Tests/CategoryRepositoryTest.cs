using FluentAssertions;
using GeCli.Back.Domain.Entities.Consumables;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Repositories;
using GeCli.FakeData.CategoryData;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GeCli.Repository.Tests
{
    public class CategoryRepositoryTest : IDisposable
    {
        readonly ICategoryRepository _categoryRepository;
        readonly ApplicationDbContext _context;
        readonly Category _category;
        readonly CategoryFake _categoryFake;

        public CategoryRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _context = new ApplicationDbContext(optionsBuilder.Options);
            _categoryRepository = new CategoryRepository(_context);

            _categoryFake = new CategoryFake();
            _category = _categoryFake.Generate();
        }

        private async Task<List<Category>> DataBase()
        {
            var categories = _categoryFake.Generate(100);

            foreach (var category in categories)
            {
                category.Id = 0;
                await _context.Categories.AddAsync(category);
            }
            await _context.SaveChangesAsync();
            return categories;
        }

        [Fact]
        public async Task GetCategories_WithReturn()
        {
            var db = await DataBase();
            var returnResult = await _categoryRepository.GetCategoriesAsync();

            returnResult.Should().HaveCount(db.Count);
        }

        [Fact]
        public async Task GetCategories_NotFound()
        {
            var returnResult = await _categoryRepository.GetCategoriesAsync();
            returnResult.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetCategoryById_Ok()
        {
            var db = await DataBase();
            var returnResult = await _categoryRepository.GetCategoryByIdAsync(db.First().Id);

            returnResult.Should().BeEquivalentTo(db.First());
        }
        
        [Fact]
        public async Task GetCategoryById_NotFound()
        {
            var returnResult = await _categoryRepository.GetCategoryByIdAsync(1);
            returnResult.Should().BeNull();
        }

        [Fact]
        public async Task InsertCategory_Ok()
        {
            var returnResult = await _categoryRepository.InsertCategoryAsync(_category);

            returnResult.Should().BeEquivalentTo(_category);
        }

        [Fact]
        public async Task UpdateCategory_Ok()
        {
            var db = await DataBase();
            var updateCategory = _categoryFake.Generate();
            updateCategory.Id = db.First().Id;
            var returnResult = await _categoryRepository.UpdateCategoryAsync(updateCategory);

            returnResult.Should().BeEquivalentTo(updateCategory);
        }

        [Fact]
        public async Task UpdateCategory_NotFound()
        {
            var returnResult = await _categoryRepository.UpdateCategoryAsync(_category);
            returnResult.Should().BeNull();
        }

        [Fact]
        public async Task DeleteCategory_NoContent()
        {
            var db = await DataBase();
            var returnResult = await _categoryRepository.DeleteCategoryAsync(db.First().Id);

            returnResult.Should().BeEquivalentTo(db.First());
        }

        [Fact]
        public async Task DeleteCategory_NotFound()
        {
            var returnResult = await _categoryRepository.DeleteCategoryAsync(1);
            returnResult.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}

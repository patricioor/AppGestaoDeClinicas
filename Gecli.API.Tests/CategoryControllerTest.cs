using FluentAssertions;
using GeCli.Back.API.Controllers;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Category;
using GeCli.FakeData.CategoryData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GeCli.API.Tests;

public class CategoryControllerTest
{
    readonly ICategoryManager _categoryManager;
    readonly CategoriesController _categoryController;
    readonly CategoryView _categoryView;
    readonly NewCategory _newCategory;
    readonly UpdateCategory _updateCategory;
    readonly List<CategoryView> _listCategoriesView;
    public CategoryControllerTest()
    {
        _categoryManager = Substitute.For<ICategoryManager>();
        _categoryController = new CategoriesController(_categoryManager);

        _listCategoriesView = new CategoryViewFake().Generate(4);
        _categoryView = new CategoryViewFake().Generate();
        _newCategory = new NewCategoryFake().Generate();
        _updateCategory = new UpdateCategoryFake().Generate();
    }

    [Fact]
    public async Task GetCategories_Ok()
    {
        var control = new List<CategoryView>();
        _listCategoriesView.ForEach(p => control.Add(p.ClonedTyped()));
        _categoryManager.GetCategoriesAsync().Returns(_listCategoriesView);

        var result = (ObjectResult)await _categoryController.Get();

        await _categoryManager.Received().GetCategoriesAsync();
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetCategories_NotFound()
    {
        _categoryManager.GetCategoriesAsync().Returns(new List<CategoryView>());

        var result = (StatusCodeResult)await _categoryController.Get();

        await _categoryManager.Received().GetCategoriesAsync();
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task GetCategoryById_Ok()
    {
        _categoryManager.GetCategoryByIdAsync(Arg.Any<int>()).Returns(_categoryView);

        var result = (ObjectResult)await _categoryController.GetById(_categoryView.Id);

        await _categoryManager.Received().GetCategoryByIdAsync(_categoryView.Id);
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetCategoryById_NotFound()
    {
        _categoryManager.GetCategoryByIdAsync(Arg.Any<int>()).ReturnsNull();

        var result = (StatusCodeResult)await _categoryController.GetById(1);

        await _categoryManager.Received().GetCategoryByIdAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task InsertCategory_Ok()
    {
        _categoryManager.InsertCategoryAsync(Arg.Any<NewCategory>()).Returns(_categoryView);

        var result = (ObjectResult)await _categoryController.Post(_newCategory);

        await _categoryManager.Received().InsertCategoryAsync(Arg.Any<NewCategory>());
        result.StatusCode.Should().Be(StatusCodes.Status201Created);
    }

    [Fact]
    public async Task UpdateCategory_Ok()
    {
        _categoryManager.UpdateCategoryAsync(Arg.Any<UpdateCategory>()).Returns(_categoryView);

        var result = (ObjectResult)await _categoryController.Put(_updateCategory);

        await _categoryManager.Received().UpdateCategoryAsync(Arg.Any<UpdateCategory>());
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task UpdateCategory_NotFound()
    {
        _categoryManager.UpdateCategoryAsync(Arg.Any<UpdateCategory>()).ReturnsNull();

        var result = (StatusCodeResult)await _categoryController.Put(_updateCategory);

        await _categoryManager.Received().UpdateCategoryAsync(Arg.Any<UpdateCategory>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task DeleteCategory_Ok()
    {
        _categoryManager.DeleteCategoryAsync(Arg.Any<int>()).Returns(_categoryView);

        var result = (StatusCodeResult)await _categoryController.Delete(_categoryView.Id);

        await _categoryManager.Received().DeleteCategoryAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteCategory_NotFound()
    {
        _categoryManager.DeleteCategoryAsync(Arg.Any<int>()).ReturnsNull();

        var result = (StatusCodeResult)await _categoryController.Delete(1);

        await _categoryManager.Received().DeleteCategoryAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}

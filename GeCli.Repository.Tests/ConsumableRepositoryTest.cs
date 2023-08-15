using FluentAssertions;
using GeCli.Back._FakeData.CategoryData;
using GeCli.Back._FakeData.ConsumableData;
using GeCli.Back.Domain.Entities.Consumables;
using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Repositories;
using GeCli.FakeData.SupplierData;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GeCli.Repository.Tests;

public class ConsumableRepositoryTest
{
    readonly IConsumableRepository _consumableRepository;
    readonly ApplicationDbContext _context;
    readonly Consumable _consumable;
    readonly ConsumableFake _consumableFake;

    public ConsumableRepositoryTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        optionsBuilder.EnableSensitiveDataLogging();

        _context = new ApplicationDbContext(optionsBuilder.Options);
        _consumableRepository = new ConsumableRepository(_context);

        _consumableFake = new ConsumableFake();
        _consumable = _consumableFake.Generate();
    }

    private async Task<List<Consumable>> RecordInsert()
    {
        List<Category> categories = await InsertCategory();
        var consumables = _consumableFake.Generate(100);

        foreach(var consumable in consumables)
        {
            consumable.Id = 0;
            var random = new Random();

            consumable.Category = categories.ElementAt(random.Next(categories.Count));
            await _context.Consumables.AddAsync(consumable);
        }
        await _context.SaveChangesAsync();
        return consumables;
    }

    private async Task<List<Category>> InsertCategory()
    {
        var categories = new CategoryFake().Generate(100);

        foreach (var category in categories)
        {
            category.Id = 0;
            await _context.Categories.AddAsync(category);
        }

        await _context.SaveChangesAsync();
        return categories;
    }

    [Fact]
    public async Task GetConsumables_Ok()
    {
        var db = await RecordInsert();
        var returnResult = await _consumableRepository.GetConsumablesAsync();

        returnResult.Should().HaveCount(db.Count);
        returnResult.First().Category.Should().NotBeNull();
        //returnResult.First().Suppliers.Should().NotBeNull();
    }    

    [Fact]
    public async Task GetConsumablesAsync_Void()
    {
        var returnResult = await _consumableRepository.GetConsumablesAsync();
        returnResult.Should().HaveCount(0);
    }

    [Fact]
    public async Task GetConsumableById_Found()
    {
        var db = await RecordInsert();
        var returnResult = await _consumableRepository.GetConsumableByIdAsync(db.First().Id);
        returnResult.Should().BeEquivalentTo(db.First());
    }

    [Fact]
    public async Task GetConsumableById_NotFound()
    {
        var returnResult = await _consumableRepository.GetConsumableByIdAsync(1);
        returnResult.Should().BeEquivalentTo(returnResult);
    }

    [Fact]
    public async Task InsertConsumable_Ok()
    {
        var returnResult = await _consumableRepository.InsertConsumableAsync(_consumable);
        returnResult.Should().BeEquivalentTo(_consumable);
    }

    [Fact]
    public async Task UpdateConsumable_Ok()
    {
        var db = await RecordInsert();
        var updateConsumable = _consumableFake.Generate();
        updateConsumable.Id = db.First().Id;

        var returnResult = await _consumableRepository.UpdateConsumableAsync(updateConsumable);
        returnResult.Should().BeEquivalentTo(updateConsumable);
    }
    // adicionar supplier
}

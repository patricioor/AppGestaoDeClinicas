using FluentAssertions;
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

public class SupplierRepositoryTest
{
    readonly ISupplierRepository _supplierRepository;
    readonly ApplicationDbContext _context;
    readonly Supplier _supplier;
    readonly SupplierFake _supplierFake;

    public SupplierRepositoryTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        optionsBuilder.EnableDetailedErrors();

        _context = new ApplicationDbContext(optionsBuilder.Options);
        _supplierRepository = new SupplierRepository(_context);

        _supplierFake = new SupplierFake();
        _supplier = _supplierFake.Generate();
    }

    private async Task<List<Supplier>> InsertSuppliers()
    {
        List<Consumable> consumables = await InsertConsumables();
        var suppliers = _supplierFake.Generate(100);

        foreach (var supplier in suppliers)
        {
            supplier.Id = 0;
            var random = new Random();
            var listCons = new List<Consumable>()
            {
                consumables.ElementAt(random.Next(consumables.Count)),
                consumables.ElementAt(random.Next(consumables.Count))
            };

            supplier.Consumables = listCons;
            await _context.Suppliers.AddAsync(supplier);
        }
        await _context.SaveChangesAsync();
        return suppliers;
    }

    private async Task<List<Consumable>> InsertConsumables()
    {
        var consumables = new ConsumableFake().Generate(10);

        foreach (var consumable in consumables)
        {
            consumable.Id = 0;
            await _context.Consumables.AddAsync(consumable);
        }

        await _context.SaveChangesAsync();
        return consumables;
    }

    [Fact]
    public async Task GetSuppliers_Ok()
    {
        var db = await InsertSuppliers();
        var returnRegister = await _supplierRepository.GetSuppliersAsync();

        returnRegister.Should().HaveCount(db.Count);
        returnRegister.First().Address.Should().NotBeNull();
        returnRegister.First().Cellphones.Should().NotBeNull();
        returnRegister.First().Consumables.Should().NotBeNull();
    }
}

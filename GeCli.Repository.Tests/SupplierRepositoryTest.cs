using FluentAssertions;
using GeCli.Back.Domain.Entities.Consumables;
using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Repositories;
using GeCli.FakeData.ConsumableData;
using GeCli.FakeData.SupplierData;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GeCli.Repository.Tests;

public class SupplierRepositoryTest : IDisposable
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
        optionsBuilder.EnableSensitiveDataLogging();

        _context = new ApplicationDbContext(optionsBuilder.Options);
        _supplierRepository = new SupplierRepository(_context);

        _supplierFake = new SupplierFake();
        _supplier = _supplierFake.Generate();
    }

    private async Task<List<Supplier>> InsertSuppliers()
    {
        List<Consumable> consumables = await InsertConsumables();
        var suppliers = _supplierFake.Generate(10);

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

    [Fact]
    public async Task GetSuppliers_Void()
    {
        var returnRegister = await _supplierRepository.GetSuppliersAsync();
        returnRegister.Should().HaveCount(0);
    }

    [Fact]
    public async Task GetSupplierById_Ok()
    {
        var db = await InsertSuppliers();
        var returnResult = await _supplierRepository.GetSupplierByIdAsync(db.First().Id);

        returnResult.Should().BeEquivalentTo(db.First());
    }

    [Fact]
    public async Task GetSupplierById_NotFound()
    {
        var returnResult = await _supplierRepository.GetSupplierByIdAsync(1);
        returnResult.Should().BeNull();
    }

    [Fact]
    public async Task InsertSupplier_Created()
    {
        var consumables = await InsertConsumables();
        var random = new Random();
        var listCons = new List<Consumable>
        {
            consumables.ElementAt(random.Next(consumables.Count)),
            consumables.ElementAt(random.Next(consumables.Count))
        };

        _supplier.Consumables = listCons;

        var returnResult = await _supplierRepository.InsertSupplierAsync(_supplier);
        returnResult.Should().BeEquivalentTo(_supplier);
    }

    [Fact]
    public async Task UpdateSupplier_Ok()
    {
        var consumables = await InsertConsumables();
        var random = new Random();
        var listCons = new List<Consumable>
        {
            consumables.ElementAt(random.Next(consumables.Count)),
            consumables.ElementAt(random.Next(consumables.Count))
        };

        var result = await InsertSuppliers();
        var updateSupplier = _supplierFake.Generate();
        updateSupplier.Id = result.First().Id;
        updateSupplier.Consumables = listCons;
        var returnResult = await _supplierRepository.UpdateSupplierAsync(updateSupplier);
        returnResult.Should().BeEquivalentTo(updateSupplier);
    }

    [Fact]
    public async Task UpdateSupplier_NotFound()
    {
        var returnResult = await _supplierRepository.UpdateSupplierAsync(_supplier);
        returnResult.Should().BeNull();
    }

    [Fact]
    public async void UpdateSupplier_AddConsumable()
    {
        await InsertSuppliers();
        var updateSupplier = await _context.Suppliers.Include(p => p.Consumables)
                                                     .Include(p => p.Cellphones)
                                                     .AsNoTracking().FirstAsync();

        var consumables = await InsertConsumables();
        var random = new Random();
        var listCons = new List<Consumable>
        {
            consumables.ElementAt(random.Next(consumables.Count)),
            consumables.ElementAt(random.Next(consumables.Count))
        };

        updateSupplier.Consumables = listCons;
        var returnResult = await _supplierRepository.UpdateSupplierAsync(updateSupplier);

        returnResult.Consumables.Should().HaveCount(updateSupplier.Consumables.Count);
    }

    //Corrigir
    [Fact]
    public async Task UpdateSupplier_RemoveConsumable()
    {
        await InsertSuppliers();

        var updateSupplier = await _context.Suppliers.Include(p => p.Consumables)
                                                     .Include(p => p.Address)
                                                     .Include(p => p.Cellphones)
                                                     .AsNoTracking().FirstAsync();

        updateSupplier.Consumables.Remove(updateSupplier.Consumables.First());
        var returnResult = await _supplierRepository.UpdateSupplierAsync(updateSupplier);

        returnResult.Consumables.Should().HaveCount(updateSupplier.Consumables.Count);
        returnResult.Consumables.First().Id.Should().Be(updateSupplier.Consumables.First().Id);
    }

    [Fact]
    public async Task DeleteAllSuppliers_NoContent()
    {
        var suppliers = await InsertSuppliers();
        var supplier = suppliers.First();
        supplier.Consumables.Clear();

        var returnResult = await _supplierRepository.UpdateSupplierAsync(supplier);

        returnResult.Should().BeEquivalentTo(supplier);
    }

    [Fact]
    public async Task DeleteSupplier_NoContent()
    {
        var db = await InsertSuppliers();
        var returnResult = await _supplierRepository.DeleteSupplierAsync(db.First().Id);

        returnResult.Should().BeEquivalentTo(db.First());
    }

    [Fact]
    public async Task DeleteSupplier_NotFound()
    {
        var returnResult = await _supplierRepository.DeleteSupplierAsync(_supplier.Id);
        returnResult.Should().BeNull();
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
    }
}

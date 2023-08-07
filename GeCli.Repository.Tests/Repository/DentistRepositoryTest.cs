using FluentAssertions;
using GeCli.Back._FakeData.DentistData;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Xunit;

namespace GeCli.Repository.Tests.Repository;

public class DentistRepositoryTest
{
    private readonly IDentistRepository _dentistRepository;
    private readonly ApplicationDbContext _context;
    private readonly Dentist _dentist;
    private readonly DentistFake _dentistFake;

    public DentistRepositoryTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        optionsBuilder.EnableSensitiveDataLogging();

        _context = new ApplicationDbContext(optionsBuilder.Options);
        _dentistRepository = new DentistRepository(_context);

        _dentistFake = new DentistFake();
        _dentist = _dentistFake.Generate();
    }

    private async Task<List<Dentist>> InsertDentists()
    {
        List<Specialty> specialties = await InsertSpecialties();
        var dentists = _dentistFake.Generate(100);

        foreach(var dentist in dentists)
        {
            dentist.Id = 0;
            var random = new Random();
            var listSpec = new List<Specialty>
            {
                specialties.ElementAt(random.Next(specialties.Count)),
                specialties.ElementAt(random.Next((specialties.Count)))
            };
            dentist.Specialties = listSpec;
            await _context.Dentists.AddAsync(dentist);
        }

        await _context.SaveChangesAsync();
        return dentists;
    }

    private async Task<List<Specialty>> InsertSpecialties()
    {
        var specialties = new SpecialtyFake().Generate(100);

        foreach( var specialty in specialties)
        {
            specialty.Id = 0;
            await _context.Specialtys.AddAsync(specialty);
        }
        await _context.SaveChangesAsync();
        return specialties;
    }

    [Fact]
    public async Task GetDentistsAsync_WithReturn()
    {
        var record = await InsertDentists();
        var returnRegister = await _dentistRepository.GetDentistsAsync();

        returnRegister.Should().HaveCount(record.Count);
        returnRegister.First().Address.Should().NotBeNull();
        returnRegister.First().Cellphones.Should().NotBeNull();
        returnRegister.First().Specialties.Should().NotBeNull();
    }

    [Fact]
    public async Task GetDentistsAsync_Void()
    {
        var returnResult = await _dentistRepository.GetDentistsAsync();
        returnResult.Should().HaveCount(0);
    }

    [Fact]
    public async Task GetDentistByIdAsync_Found()
    {
        var records = await InsertDentists();
        var returnResult = await _dentistRepository.GetDentistByIdAsync(records.First().Id);
        returnResult.Should().BeEquivalentTo(records.First());
    }

    [Fact]
    public async Task GetDentistByIdAsync_NotFound()
    {
        var returnResult = await _dentistRepository.GetDentistByIdAsync(1);
        returnResult.Should().BeNull();
    }

    [Fact]
    public async Task InsertDentist_Ok()
    {
        var specialties = await InsertSpecialties();
        var random = new Random();
        var listSpec = new List<Specialty>
        {
            specialties.ElementAt(random.Next(specialties.Count)),
            specialties.ElementAt(random.Next(specialties.Count))
        };

        _dentist.Specialties = listSpec;

        var returnResult = await _dentistRepository.InsertDentistAsync(_dentist);
        returnResult.Should().BeEquivalentTo(_dentist);
    }

    [Fact]
    public async void UpdateDentist_Ok()
    {
        var specialties = await InsertSpecialties();
        var random = new Random();
        var listSpec = new List<Specialty>
        {
            specialties.ElementAt(random.Next(specialties.Count)),
            specialties.ElementAt(random.Next(specialties.Count))
        };

        var result = await InsertDentists();
        var updatedDentist = _dentistFake.Generate();
        updatedDentist.Id = result.First().Id;
        updatedDentist.Specialties = listSpec;
        var returnResult = await _dentistRepository.UpdateDentistAsync(updatedDentist);
        returnResult.Should().BeEquivalentTo(updatedDentist);
    }

    //corrigir
    [Fact]
    public async void UpdateDentist_addSpecialty()
    {
        await InsertDentists();
        await InsertSpecialties();

        var updatedDentist = await _context.Dentists.Include(p => p.Specialties).AsNoTracking().FirstAsync();

        var specialty = await _context.Specialtys.Where(p => !updatedDentist
                                                             .Specialties
                                                             .Select(i => i.Id)
                                                             .Contains(p.Id))
                                                 .AsNoTracking().FirstAsync();

        updatedDentist.Specialties.Add(specialty);
        var returnResult = await _dentistRepository.UpdateDentistAsync(updatedDentist);

        returnResult.Specialties.Should().HaveCount(updatedDentist.Specialties.Count);
    }
}

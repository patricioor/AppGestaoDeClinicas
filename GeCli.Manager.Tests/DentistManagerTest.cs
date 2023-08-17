using AutoMapper;
using FluentAssertions;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Manager.Mappings;
using GeCli.Back.Shared.ModelView.Employees;
using GeCli.FakeData.DentistData;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GeCli.Manager.Tests;

public class DentistManagerTest
{
    readonly IDentistManager _dentistManager;
    readonly IDentistRepository _dentistRepository;
    readonly IMapper _mapper;
    readonly Dentist _dentist;
    readonly NewDentist _newDentist;
    readonly UpdateDentist _updateDentist;
    readonly DentistFake _dentistFake;
    readonly NewDentistFake _newDentistFake;
    readonly UpdateDentistFake _updateDentistFake;
    public DentistManagerTest()
    {
        _dentistRepository = Substitute.For<IDentistRepository>();
        _mapper = new MapperConfiguration(p => p.AddProfile<DentistMappingProfile>()).CreateMapper();

        _dentistManager = new DentistManager(_dentistRepository, _mapper);
        _dentistFake = new DentistFake();
        _newDentistFake = new NewDentistFake();
        _updateDentistFake = new UpdateDentistFake();

        _dentist = _dentistFake.Generate();
        _newDentist = _newDentistFake.Generate();
        _updateDentist = _updateDentistFake.Generate();
    }

    [Fact]
    public async Task GetDentists_Ok()
    {
        var listDentist = _dentistFake.Generate(10);
        _dentistRepository.GetDentistsAsync().Returns(listDentist);

        var control = _mapper.Map<IEnumerable<Dentist>, IEnumerable<DentistView>>(listDentist);
        var returnResult = await _dentistManager.GetDentistsAsync();

        await _dentistRepository.Received().GetDentistsAsync();
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task GetDentists_Void()
    {
        _dentistRepository.GetDentistsAsync().Returns(new List<Dentist>());

        var returnResult = await _dentistManager.GetDentistsAsync();

        await _dentistRepository.Received().GetDentistsAsync();
        returnResult.Should().BeEquivalentTo(new List<Dentist>());
    }

    [Fact]
    public async Task GetDentistById_Ok()
    {
        _dentistRepository.GetDentistByIdAsync(Arg.Any<int>()).Returns(_dentist);

        var control = _mapper.Map<DentistView>(_dentist);
        var returnResult = await _dentistManager.GetDentistByIdAsync(control.Id);

        await _dentistRepository.Received().GetDentistByIdAsync(Arg.Any<int>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task GetDentistById_NotFound()
    {
        _dentistRepository.GetDentistByIdAsync(Arg.Any<int>()).Returns(new Dentist());

        var control = _mapper.Map<DentistView>(new Dentist());
        var returnResult = await _dentistManager.GetDentistByIdAsync(control.Id);

        await _dentistRepository.Received().GetDentistByIdAsync(Arg.Any<int>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task InsertDentist_Ok()
    {
        _dentistRepository.InsertDentistAsync(Arg.Any<Dentist>()).Returns(_dentist);

        var control = _mapper.Map<DentistView>(_dentist);
        var returnResult = await _dentistManager.InsertDentistAsync(_newDentist);

        await _dentistRepository.Received().InsertDentistAsync(Arg.Any<Dentist>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task UpdateDentist_Ok()
    {
        _dentistRepository.UpdateDentistAsync(Arg.Any<Dentist>()).Returns(_dentist);

        var control = _mapper.Map<DentistView>(_dentist);
        var returnResult = await _dentistManager.UpdateDentistAsync(_updateDentist);

        await _dentistRepository.Received().UpdateDentistAsync(Arg.Any<Dentist>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task UpdateDentist_NotFound()
    {
        _dentistRepository.UpdateDentistAsync(Arg.Any<Dentist>()).ReturnsNull();

        var returnResult = await _dentistManager.UpdateDentistAsync(_updateDentist);

        await _dentistRepository.Received().UpdateDentistAsync(Arg.Any<Dentist>());
        returnResult.Should().BeNull();
    }

    [Fact]
    public async Task DeleteDentist_Ok()
    {
        _dentistRepository.DeleteDentistAsync(Arg.Any<int>()).Returns(_dentist);

        var control = _mapper.Map<DentistView>(_dentist);
        var returnResult = await _dentistManager.DeleteDentistAsync(control.Id);

        await _dentistRepository.Received().DeleteDentistAsync(Arg.Any<int>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task DeleteDentist_NotFound()
    {
        _dentistRepository.DeleteDentistAsync(Arg.Any<int>()).ReturnsNull();

        var returnResult = await _dentistManager.DeleteDentistAsync(1);

        await _dentistRepository.Received().DeleteDentistAsync(Arg.Any<int>());
        returnResult.Should().BeNull();
    }
}

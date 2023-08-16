using FluentAssertions;
using GeCli.Back.API.Controllers;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Employees;
using GeCli.FakeData.DentistData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Gecli.API.Tests;
public class DentistControllerTest
{
    readonly IDentistManager _manager;
    readonly DentistController _controller;
    readonly DentistView _dentistView;
    readonly NewDentist _newDentist;
    readonly List<DentistView> _listDentistViews;

    public DentistControllerTest()
    {
        _manager = Substitute.For<IDentistManager>();
        _controller = new DentistController(_manager);

        _listDentistViews = new DentistViewFake().Generate(4);
        _dentistView = new DentistViewFake().Generate();
        _newDentist = new NewDentistFake().Generate();
    }

    [Fact]
    public async Task GetDentists_Ok()
    {
        var control = new List<DentistView>();
        _listDentistViews.ForEach(p => control.Add(p.CloneTyped()));
        _manager.GetDentistsAsync().Returns(_listDentistViews);

        var result = (ObjectResult)await _controller.Get();

        await _manager.Received().GetDentistsAsync();
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetDentists_NotFound()
    {
        _manager.GetDentistsAsync().Returns(new List<DentistView>());

        var result = (StatusCodeResult)await _controller.Get();

        await _manager.Received().GetDentistsAsync();
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task GetById_Ok()
    {
        _manager.GetDentistByIdAsync(Arg.Any<int>()).Returns(_dentistView.CloneTyped());

        var result = (ObjectResult)await _controller.GetById(_dentistView.Id);

        await _manager.Received().GetDentistByIdAsync(Arg.Any<int>());
        result.Value.Should().BeEquivalentTo(_dentistView);
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetById_NotFound()
    {
        _manager.GetDentistByIdAsync(Arg.Any<int>()).Returns(new DentistView());

        var result = (StatusCodeResult)await _controller.GetById(1);

        await _manager.Received().GetDentistByIdAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Insert_Ok()
    {
        _manager.InsertDentistAsync(Arg.Any<NewDentist>()).Returns(_dentistView.CloneTyped());

        var result = (ObjectResult)await _controller.Post(_newDentist);

        await _manager.Received().InsertDentistAsync(Arg.Any<NewDentist>());
        result.StatusCode.Should().Be(StatusCodes.Status201Created);
        result.Value.Should().BeEquivalentTo(_dentistView);
    }

    [Fact]
    public async Task Put_Ok()
    {
        _manager.UpdateDentistAsync(Arg.Any<UpdateDentist>()).Returns(_dentistView.CloneTyped());

        var result = (ObjectResult)await _controller.Put(new UpdateDentist());

        await _manager.Received().UpdateDentistAsync(Arg.Any<UpdateDentist>());
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Value.Should().BeEquivalentTo(_dentistView);
    }

    [Fact]
    public async Task UpdateDentist_NotFound()
    {
        _manager.UpdateDentistAsync(Arg.Any<UpdateDentist>()).ReturnsNull();

        var result = (StatusCodeResult)await _controller.Put(new UpdateDentist());

        await _manager.Received().UpdateDentistAsync(Arg.Any<UpdateDentist>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task Delete_NoContent()
    {
        _manager.DeleteDentistAsync(Arg.Any<int>()).Returns(_dentistView.CloneTyped());

        var result = (StatusCodeResult)await _controller.Delete(1);

        await _manager.Received().DeleteDentistAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task Delete_NotFound()
    {
        _manager.DeleteDentistAsync(Arg.Any<int>()).ReturnsNull();

        var result = (StatusCodeResult)await _controller.Delete(1);

        await _manager.Received().DeleteDentistAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}

using FluentAssertions;
using GeCli.Back._FakeData.DentistData;
using GeCli.Back.API.Controllers;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
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
    public async Task Get_Ok()
    {
        var control = new List<DentistView>();
        _listDentistViews.ForEach(p => control.Add(p.CloneTyped()));
        _manager.GetDentistsAsync().Returns(_listDentistViews);

        var result = (ObjectResult)await _controller.Get();

        await _manager.Received().GetDentistsAsync();
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task Get_NotFound()
    {
        _manager.GetDentistsAsync().Returns(new List<DentistView>());

        var result = (StatusCodeResult)await _controller.Get();

        await _manager.Received().GetDentistsAsync();
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}

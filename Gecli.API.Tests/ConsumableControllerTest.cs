using FluentAssertions;
using GeCli.Back.API.Controllers;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Consumable;
using GeCli.FakeData.ConsumableData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GeCli.API.Tests;

public class ConsumableControllerTest
{
    readonly IConsumableManager _consumableManager;
    readonly ConsumableController _consumableController;
    readonly ConsumableView _consumableView;
    readonly NewConsumable _newConsumable;
    readonly UpdateConsumable _updateConsumable;
    readonly List<ConsumableView> _listConsumableView;

    public ConsumableControllerTest()
    {
        _consumableManager = Substitute.For<IConsumableManager>();
        _consumableController = new ConsumableController(_consumableManager);

        _listConsumableView = new ConsumableViewFake().Generate(4);
        _consumableView = new ConsumableViewFake().Generate();
        _newConsumable = new NewConsumableFake().Generate();
        _updateConsumable = new UpdateConsumableFake().Generate();
    }

    [Fact]
    public async Task GetConsumables_Ok()
    {
        var control = new List<ConsumableView>();
        _listConsumableView.ForEach(p => control.Add(p.ClonedTyped()));
        _consumableManager.GetConsumablesAsync().Returns(_listConsumableView);

        var result = (ObjectResult)await _consumableController.Get();

        await _consumableManager.Received().GetConsumablesAsync();
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetConsumables_NotFound()
    {
        _consumableManager.GetConsumablesAsync().Returns(new List<ConsumableView>());

        var result = (StatusCodeResult)await _consumableController.Get();

        await _consumableManager.Received().GetConsumablesAsync();
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task GetConsumableById_Ok()
    {
        _consumableManager.GetConsumableByIdAsync(Arg.Any<int>()).Returns(_consumableView);

        var result = (ObjectResult)await _consumableController.GetById(_consumableView.Id);

        await _consumableManager.Received().GetConsumableByIdAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetConsumableById_NotFound()
    {
        _consumableManager.GetConsumableByIdAsync(Arg.Any<int>()).Returns(new ConsumableView());

        var result = (StatusCodeResult)await _consumableController.GetById(1);

        await _consumableManager.Received().GetConsumableByIdAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task InsertConsumable_Ok()
    {
        _consumableManager.InsertConsumableAsync(Arg.Any<NewConsumable>()).Returns(_consumableView);

        var result = (ObjectResult)await _consumableController.Post(_newConsumable);

        await _consumableManager.Received().InsertConsumableAsync(Arg.Any<NewConsumable>());
        result.StatusCode.Should().Be(StatusCodes.Status201Created);
    }

    [Fact]
    public async Task UpdateConsumable_Ok()
    {
        _consumableManager.UpdateConsumableAsync(Arg.Any<UpdateConsumable>()).Returns(_consumableView);

        var result = (ObjectResult)await _consumableController.Put(_updateConsumable);

        await _consumableManager.Received().UpdateConsumableAsync(Arg.Any<UpdateConsumable>());
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task UpdateConsumable_NotFound()
    {
        _consumableManager.UpdateConsumableAsync(Arg.Any<UpdateConsumable>()).ReturnsNull();

        var result = (StatusCodeResult)await _consumableController.Put(new UpdateConsumable());

        await _consumableManager.Received().UpdateConsumableAsync(Arg.Any<UpdateConsumable>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task DeleteConsumable_NoContent()
    {
        _consumableManager.DeleteConsumableAsync(Arg.Any<int>()).Returns(_consumableView);

        var result = (StatusCodeResult)await _consumableController.Delete(1);

        await _consumableManager.Received().DeleteConsumableAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteConsumable_NotFound()
    {
        _consumableManager.DeleteConsumableAsync(Arg.Any<int>()).ReturnsNull();

        var result = (StatusCodeResult)await _consumableController.Delete(1);

        await _consumableManager.Received().DeleteConsumableAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}

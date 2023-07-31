using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Consumable;
using GeCli.Back.Shared.ModelView.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumableController : ControllerBase
{
    readonly IConsumableManager _consumableManager;
    public ConsumableController(IConsumableManager consumableManager)
    {
        _consumableManager = consumableManager;
    }

    /// <summary>
    /// Return all consumables registered in the database.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ConsumableView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get()
    {
        var consumable = await _consumableManager.GetConsumablesAsync();
        if (consumable.Any()) return Ok(consumable);

        return BadRequest();
    }
}

using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Consumable;
using GeCli.Back.Shared.ModelView.Customer;
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
    /// Return all consumable registered in the database.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ConsumableView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get()
    {
        var consumable = await _consumableManager.GetConsumablesAsync();

        if (consumable.Any())
            return Ok(consumable);
        return NotFound();
    }


    /// <summary>
    /// Returns a consumable queried by id.
    /// </summary>
    /// <param name="id" example="1"> Id of consumable.</param>
    [HttpGet("{id:int}", Name = "GetConsumable")]
    [ProducesResponseType(typeof(ConsumableView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetById(int id)
    {
        var consumable = await _consumableManager.GetConsumableByIdAsync(id);

        if (consumable.Id == 0)
            return NotFound();

        return Ok(consumable);
    }

    /// <summary>
    /// Insert new consumable
    /// </summary>
    /// <param name="newConsumable"></param>
    [HttpPost]
    [ProducesResponseType(typeof(CustomerView), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post(NewConsumable newConsumable)
    {
        var insertConsumable = await _consumableManager.InsertConsumableAsync(newConsumable);
        return new CreatedAtRouteResult("GetConsumable", new { id = insertConsumable.Id }, insertConsumable);
    }

    /// <summary>
    /// Update an existing consumable.
    /// </summary>
    /// <param name="updateConsumable"></param>
    /// <remarks>When modifying a consumable, it will be permanently changed in the database.</remarks>
    [HttpPut]
    [ProducesResponseType(typeof(ConsumableView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Put(UpdateConsumable updateConsumable)
    {
        var UpdatedConsumable = await _consumableManager.UpdateConsumableAsync(updateConsumable);
        if (UpdatedConsumable == null)
            return NotFound();

        return Ok(UpdatedConsumable);
    }

    /// <summary>
    /// Delete an existing consumable based on id.
    /// </summary>
    /// <param name="id" example="1">Id of customer</param>
    /// <remarks>When deleting a consumable, it will be permanently removed from the database.</remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(int id)
    {
        var customer = await _consumableManager.DeleteConsumableAsync(id);
        if (customer == null)
            return NotFound();

        return NoContent();
    }
}

using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    readonly ISupplierManager _supplierManager;
    public SupplierController(ISupplierManager supplierManager)
    {
        _supplierManager = supplierManager;
    }

    /// <summary>
    /// Return all suppliers registered in the database.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(SupplierView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Get()
    {
        var supplier = await _supplierManager.GetSuppliersAsync();

        if (supplier.Any())
            return Ok(supplier);
        return BadRequest();
    }

    /// <summary>
    /// Returns a customer queried by id.
    /// </summary>
    /// <param name="id" example="1"> Id of supplier.</param>
    [HttpGet("{id:int}", Name = "GetSupplier")]
    [ProducesResponseType(typeof(SupplierView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetById(int id)
    {
        var supplier = await _supplierManager.GetSupplierByIdAsync(id);

        if (supplier.Id == 0)
            return NotFound();

        return Ok(supplier);
    }

    /// <summary>
    /// Insert new supplier
    /// </summary>
    /// <param name="newSupplier"></param>
    [HttpPost]
    [ProducesResponseType(typeof(SupplierView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post(NewSupplier newSupplier)
    {
        var insertSupplier = await _supplierManager.InsertSupplierAsync(newSupplier);
        return new CreatedAtRouteResult("GetSupplier", new { id = insertSupplier.Id }, insertSupplier);
    }

    /// <summary>
    /// Update an existing supplier.
    /// </summary>
    /// <param name="updateSupplier"></param>
    /// <remarks>When modifying a supplier, it will be permanently changed in the database.</remarks>
    [HttpPut]
    [ProducesResponseType(typeof(SupplierView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Put(UpdateSupplier updateSupplier)
    {
        var supplierUpdated = await _supplierManager.UpdateSupplierAsync(updateSupplier);
        if (supplierUpdated == null) return NotFound();

        return Ok(supplierUpdated);
    }

    /// <summary>
    /// Delete an existing supplier based on id.
    /// </summary>
    /// <param name="id" example="1">Id of supplier</param>
    /// <remarks>When deleting a supplier, it will be permanently removed from the database.</remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(int id)
    {
        var supplier = await _supplierManager.DeleteSupplierAsync(id);
        if (supplier == null)
            return NotFound();

        return NoContent();
    }
}

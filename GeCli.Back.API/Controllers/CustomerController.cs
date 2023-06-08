using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Customer;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _customerManager.GetCustomersAsync());
        }

        [HttpGet("{id:int}", Name = "GetCustomer")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _customerManager.GetCustomerByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(NewCustomer newCustomer)
        {
            var insertCustomer = await _customerManager.InsertCustomerAsync(newCustomer);
            return new CreatedAtRouteResult("GetCustomer", new { id = insertCustomer.Id }, insertCustomer);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateCustomer updateCustomer)
        {
            var customerUpdated = await _customerManager.UpdateCustomerAsync(updateCustomer);
            if (customerUpdated == null)
                return NotFound();

            return Ok(customerUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerManager.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}

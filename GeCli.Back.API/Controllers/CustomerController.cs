using GeCli.Back.Domain.Entities;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Customer;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        private readonly ILogger _logger;
        public CustomerController(ICustomerManager customerManager, ILogger<Customer> logger)
        {
            _customerManager = customerManager;
            _logger = logger;
        }
        /// <summary>
        /// Return all customers registered in the database.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            return Ok(await _customerManager.GetCustomersAsync());
        }

        /// <summary>
        /// Returns a customer queried by id.
        /// </summary>
        /// <param name="id" example="1"> Id of customer.</param>
        [HttpGet("{id:int}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            var customer = await _customerManager.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <param name="newCustomer"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(NewCustomer newCustomer)
        {
            Customer insertCustomer;
            _logger.LogInformation("Receive Object Name: {newCustomer.Name}");
            using (Operation.Time("Time for insert customer."))
            {
                _logger.LogInformation("new customer has been requested to be inserted");
                insertCustomer = await _customerManager.InsertCustomerAsync(newCustomer);
            }
            return new CreatedAtRouteResult("GetCustomer", new { id = insertCustomer.Id }, insertCustomer);
        }

        /// <summary>
        /// Update an existing customer.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <remarks>When modifying a customer, it will be permanently changed in the database.</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(UpdateCustomer updateCustomer)
         {
            var customerUpdated = await _customerManager.UpdateCustomerAsync(updateCustomer);
            if (customerUpdated == null)
                return NotFound();

            return Ok(customerUpdated);
        }

        /// <summary>
        /// Delete an existing customer based on id.
        /// </summary>
        /// <param name="id" example="1">Id of customer</param>
        /// <remarks>When deleting a customer, it will be permanently removed from the database.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _customerManager.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            await _customerManager.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}

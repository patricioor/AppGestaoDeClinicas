using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Customer;
using GeCli.Back.Shared.ModelView.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistController : ControllerBase
    {
        private readonly IDentistManager _dentistManager;
        private readonly ILogger _logger;

        public DentistController(IDentistManager dentistManager, ILogger logger)
        {
            _dentistManager = dentistManager;
            _logger = logger;
        }

        /// <summary>
        /// Return all dentist registered in the database.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Dentist), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dentistManager.GetDentistsAsync());
        }

        /// <summary>
        /// Returns a dentist queried by id.
        /// </summary>
        /// <param name="id" example="1"> Id of dentist.</param>
        [HttpGet("{id:int}", Name = "GetDentist")]
        [ProducesResponseType(typeof(Dentist), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            var customer = await _dentistManager.GetDentistByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        /// <summary>
        /// Insert new dentist
        /// </summary>
        /// <param name="newDentist"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Dentist), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(NewDentist newDentist)
        {
            Dentist insertDentist;
            _logger.LogInformation("Receive Object Name: {newDentist.Name}");
            using (Operation.Time("Time for insert dentist."))
            {
                _logger.LogInformation("new dentist has been requested to be inserted");
                insertDentist = await _dentistManager.InsertDentistAsync(newDentist);
            }

            return new CreatedAtRouteResult("GetDentist", new { id = insertDentist.Id }, insertDentist);
        }

        /// <summary>
        /// Update an existing dentist.
        /// </summary>
        /// <param name="updateDentist"></param>
        /// <remarks>When modifying a customer, it will be permanently changed in the database.</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(Dentist), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(UpdateDentist updateDentist)
        {
            var dentistUpdated = await _dentistManager.UpdateDentistAsync(updateDentist);
            if (dentistUpdated == null)
                return NotFound();

            return Ok(dentistUpdated);
        }

        /// <summary>
        /// Delete an existing dentist based on id.
        /// </summary>
        /// <param name="id" example="1">Id of dentist</param>
        /// <remarks>When deleting a dentist, it will be permanently removed from the database.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Dentist), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _dentistManager.GetDentistByIdAsync(id);
            if (customer == null)
                return NotFound();

            await _dentistManager.DeleteDentistAsync(id);
            return NoContent();
        }
    }
}

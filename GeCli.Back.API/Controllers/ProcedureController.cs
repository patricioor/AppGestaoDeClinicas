using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;
        private readonly IConsumableService _consumableService;

        public ProcedureController(IProcedureService procedureService, IConsumableService consumableService)
        {
            _procedureService = procedureService;
            _consumableService = consumableService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedureDTO>>> Get()
        {
            var procedures = _procedureService.GetProceduresAsync();

            if(procedures == null)
                return NotFound("Procedures not found");

            return Ok(procedures);
        }

        [HttpGet("{id:int}", Name = "GetProcedureById")]
        public async Task<ActionResult<ProcedureDTO>> Get(int id)
        {
            var procedure = _procedureService.GetProcedureByIdAsync(id);

            if (procedure == null)
                return NotFound("Procedure not found");

            return Ok(procedure);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProcedureDTO procedureDTO)
        {
            if (procedureDTO == null)
                return BadRequest();

            await _procedureService.CreateProcedureAsync(procedureDTO);
            return CreatedAtRoute("GetProcedureById", new {id = procedureDTO.Id}, procedureDTO);
        }
    }
}

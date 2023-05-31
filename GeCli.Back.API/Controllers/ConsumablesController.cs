using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumablesController : ControllerBase
    {
        private readonly IConsumableService _consumableService;

        public ConsumablesController(IConsumableService consumableService)
        {
            _consumableService = consumableService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumableDTO>>> Get()
        {
            var consumables = await _consumableService.GetConsumables();

            if(consumables == null)
                return NotFound("Consumables not found");

            return Ok(consumables);
        }

        [HttpGet("{id:int}", Name = "GetConsumable")]
        public async Task<ActionResult<ConsumableDTO>> Get(int id)
        {
            var consumable = await _consumableService.GetConsumableById(id);

            if (consumable == null)
                return NotFound("Consumable not found");

            return Ok(consumable);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConsumableDTO consumableDTO)
        {
            if (consumableDTO == null)
                return BadRequest();

            await _consumableService.Create(consumableDTO);
            return new CreatedAtRouteResult("GetConsumable", new {id = consumableDTO.Id}, consumableDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ConsumableDTO consumableDTO)
        {
            if (id != consumableDTO.Id)
                return BadRequest();

            if (consumableDTO == null)
                return BadRequest();

            await _consumableService.Update(consumableDTO);
            return Ok(consumableDTO);
        }

        [HttpDelete]
        public async Task<ActionResult<ConsumableDTO>> Delete(int id)
        {
            var consumable = _consumableService.GetConsumableById(id).Result;
            if (consumable == null)
                return NotFound("Consumable not found");

            await _consumableService.Delete(id);
            return Ok(consumable);
        }
    }
}

using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Informe6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoService _service;
        public ContratoController(IContratoService service)
        {
            _service = service;
        }

        [HttpGet("api/v1/listarEquipo")]
        public async Task<IEnumerable<ContratoDtoOut>> GetAllContrato()
        {
            return await _service.GetAllContrato();
        }

        [HttpGet("api/v1/buscarEquipo/{id}")]
        public async Task<ActionResult<ContratoDtoOut>> GetByIdContrato(int id)
        {
            var contrato = await _service.GetByIdContrato(id);
            if(contrato == null)
            {
                return NotFound("El contrato con ese id NO EXISTE");
            }
            return Ok(contrato);
        }
        [HttpPost("api/v1/createcontrato")]
        public async Task<IActionResult> CreateContrato(ContratoDtoIn contratoDto)
        {
            var newContrato = await _service.CreateContrato(contratoDto);

            return CreatedAtAction(nameof(GetByIdContrato), new {id = newContrato.Id}, newContrato);
        }

        [HttpPut("api/v1/updateContrato/{id}")]
        public async Task<IActionResult> UpdateContrato(int id, ContratoDtoIn contratoDto)
        {
            var contratoExist = await GetByIdContrato(id);
            if(contratoExist == null)
            {
                return NotFound("El contrato con este id no existe");
            }
            if(contratoExist is not null)
            {
                await _service.UpdateContrato(id, contratoDto);
                return Ok("Listo");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("api/v1/deletecontrato/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _service.GetByIdContrato(id);

            if (toDelete is not null)
            {
                await _service.Delete(id);
                return Ok("Contrato Eliminada");
            }
            else
            {
                return NotFound("No existe Contrato Con ese ID");
            }
        }
    }
}

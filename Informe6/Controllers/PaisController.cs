using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Informe6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;
        public PaisController(IPaisService service)
        {
            _service = service;
        }

        [HttpGet("api/v1/listarPais")]
        public async Task<IEnumerable<PaisDtoOut>> GetAllPais()
        {
            return await _service.GetAllPais();
        }

        [HttpGet("api/v1/buscarPais/{id}")]
        public async Task<ActionResult<PaisDtoOut>> GetByIdPais(int id)
        {
            var pais = await _service.GetByIdPais(id);
            if (pais == null)
            {
                return NotFound("El pais con ese id NO EXISTE");
            }
            return Ok(pais);
        }
        [HttpPost("api/v1/createpais")]
        public async Task<IActionResult> CreatePais(PaisDtoIn paisDto)
        {
            var newPais = await _service.CreatePais(paisDto);

            return CreatedAtAction(nameof(GetByIdPais), new { id = newPais.Id }, newPais);
        }
        [HttpPut("api/v1/updatepais/{id}")]
        public async Task<IActionResult> UpdatePais(int id, PaisDtoIn paisDto)
        {
            var exis = await GetByIdPais(id);
            if (exis is not null)
            {
                await _service.UpdatePais(id, paisDto);
                return Ok("Listo");
            }
            if (exis == null)
            {
                return NotFound("No existe pais con ese ID");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("api/v1/deletepais/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _service.GetByIdPais(id);

            if (toDelete is not null)
            {
                await _service.Delete(id);
                return Ok("Pais Eliminada");
            }
            else
            {
                return NotFound("No existe Pais Con ese ID");
            }
        }
    }
}

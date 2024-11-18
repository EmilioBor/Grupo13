using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Informe6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaEquipoController : ControllerBase
    {
        private readonly IPruebaEquipoService _service;
        public PruebaEquipoController(IPruebaEquipoService service)
        {
            _service = service;
        }

        [HttpGet("api/v1/listarPruebaEquipo")]
        public async Task<IEnumerable<PruebaEquipoDtoOut>> GetAllPruebaEquipo()
        {
            return await _service.GetAllPruebaEquipo();
        }

        [HttpGet("api/v1/buscarPruebaEquipo/{id}")]
        public async Task<ActionResult<PruebaEquipoDtoOut>> GetByIdPruebaEquipo(int id)
        {
            var pruebaEquipo = await _service.GetByIdPruebaEquipo(id);
            if (pruebaEquipo == null)
            {
                return NotFound("El pruebaEquipo con ese id NO EXISTE");
            }
            return Ok(pruebaEquipo);
        }
        [HttpPost("api/v1/createpruebaEquipo")]
        public async Task<IActionResult> CreatePruebaEquipo(PruebaEquipoDtoIn pruebaEquipoDto)
        {
            var newPruebaEquipo = await _service.CreatePruebaEquipo(pruebaEquipoDto);

            return CreatedAtAction(nameof(GetByIdPruebaEquipo), new { id = newPruebaEquipo.Id }, newPruebaEquipo);
        }
        [HttpPut("api/v1/updatepruebaequipo/{id}")]
        public async Task<IActionResult> UpdatePruebaEquipo(int id, PruebaEquipoDtoIn pruebaEquipoDto)
        {
            var exis = await GetByIdPruebaEquipo(id);
            if (exis is not null)
            {
                await _service.UpdatePruebaEquipo(id, pruebaEquipoDto);
                return Ok("Listo");
            }
            if (exis == null)
            {
                return NotFound("No existe pruebaequipo con ese ID");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("api/v1/deletepruebaequipo/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _service.GetByIdPruebaEquipo(id);

            if (toDelete is not null)
            {
                await _service.Delete(id);
                return Ok("PruebaEquipo Eliminada");
            }
            else
            {
                return NotFound("No existe Prueba Equipo Con ese ID");
            }
        }
    }
}

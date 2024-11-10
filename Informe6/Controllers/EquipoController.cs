using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Informe6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService _service;
        public EquipoController(IEquipoService service)
        {
            _service = service;
        }

        [HttpGet("api/v1/listarEquipo")]
        public async Task<IEnumerable<EquipoDtoOut>> GetAllEquipo()
        {
            return await _service.GetAllEquipo();
        }

        [HttpGet("api/v1/buscarEquipo/{id}")]
        public async Task<ActionResult<EquipoDtoOut>> GetByIdEquipo(int id)
        {
            var equipo = await _service.GetByIdEquipo(id);
            if (equipo == null)
            {
                return NotFound("El equipo con ese id NO EXISTE");
            }
            return Ok(equipo);
        }
        [HttpPost("api/v1/createequipo")]
        public async Task<IActionResult> CreateEquipo(EquipoDtoIn equipoDto)
        {
            var newEquipo = await _service.CreateEquipo(equipoDto);

            return CreatedAtAction(nameof(GetByIdEquipo), new { id = newEquipo.Id }, newEquipo);
        }
    }
}

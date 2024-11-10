using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Informe6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly IPruebaService _service;
        public PruebaController(IPruebaService service)
        {
            _service = service;
        }

        [HttpGet("api/v1/listarPrueba")]
        public async Task<IEnumerable<PruebaDtoOut>> GetAllPrueba()
        {
            return await _service.GetAllPrueba();
        }

        [HttpGet("api/v1/buscarPrueba/{id}")]
        public async Task<ActionResult<PruebaDtoOut>> GetByIdPrueba(int id)
        {
            var prueba = await _service.GetByIdPrueba(id);
            if (prueba == null)
            {
                return NotFound("El prueba con ese id NO EXISTE");
            }
            return Ok(prueba);
        }
        [HttpPost("api/v1/createprueba")]
        public async Task<IActionResult> CreatePrueba(PruebaDtoIn pruebaDto)
        {
            var newPrueba = await _service.CreatePrueba(pruebaDto);

            return CreatedAtAction(nameof(GetByIdPrueba), new { id = newPrueba.Id }, newPrueba);
        }
    }
}

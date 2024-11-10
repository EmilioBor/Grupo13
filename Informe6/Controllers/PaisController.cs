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
    }
}

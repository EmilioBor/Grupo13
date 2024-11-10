using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Informe6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _service;
        public PersonaController(IPersonaService service)
        {
            _service = service;
        }

        [HttpGet("api/v1/listarPersona")]
        public async Task<IEnumerable<PersonaDtoOut>> GetAllPersona()
        {
            return await _service.GetAllPersona();
        }

        [HttpGet("api/v1/buscarPersona/{id}")]
        public async Task<ActionResult<PersonaDtoOut>> GetByIdPersona(int id)
        {
            var persona = await _service.GetByIdPersona(id);
            if (persona == null)
            {
                return NotFound("El persona con ese id NO EXISTE");
            }
            return Ok(persona);
        }
        [HttpPost("api/v1/createpersona")]
        public async Task<IActionResult> CreatePersona(PersonaDtoIn personaDto)
        {
            var newPersona = await _service.CreatePersona(personaDto);

            return CreatedAtAction(nameof(GetByIdPersona), new { id = newPersona.Id }, newPersona);
        }
    }
}

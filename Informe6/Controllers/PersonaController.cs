using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Informe6.Controllers
{
    //[Route("api/[controller]")]
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
        [HttpGet("api/v1/buscarciclista")]
        public async Task<IEnumerable<PersonaDtoOut?>> GetCiclista()
        {
            return await _service.GetCiclista();
        }
        [HttpGet("api/v1/buscardirector")]
        public async Task<IEnumerable<PersonaDtoOut?>> GetByRol()
        {
            return await _service.GetByRolPersona();
        }
        [HttpPost("api/v1/createpersona")]
        public async Task<IActionResult> CreatePersona(PersonaDtoIn personaDto)
        {
            var newPersona = await _service.CreatePersona(personaDto);

            return CreatedAtAction(nameof(GetByIdPersona), new { id = newPersona.Id }, newPersona);
        }
        [HttpPut("api/v1/updatepersona/{id}")]
        public async Task<IActionResult> UpdatePersona(int id, PersonaDtoIn personaDto)
        {
            var exis = await GetByIdPersona(id);
            if (exis is not null)
            {
                await _service.UpdatePersona(id, personaDto);
                return Ok("Listo");
            }
            if (exis == null)
            {
                return NotFound("No existe persona con ese ID");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("api/v1/deletepersona/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDelete = await _service.GetByIdPersona(id);

            if (toDelete is not null)
            {
                await _service.Delete(id);
                return Ok("Persona Eliminada");
            }
            else
            {
                return NotFound("No existe Persona Con ese ID");
            }
        }
    }
}

using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDtoOut>> GetAllPersona();
        Task<PersonaDtoOut?> GetByIdPersona(int id);
        Task<Persona> CreatePersona(PersonaDtoIn personaDto);
    }
}
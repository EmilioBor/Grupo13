using Core.Request;
using Core.Response;
using Data.Models;
using System.Text.RegularExpressions;

namespace Services.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDtoOut>> GetAllPersona();
        Task<PersonaDtoOut?> GetByIdPersona(int id);
        Task<Persona?> GetById(int id);
        Task<Persona> CreatePersona(PersonaDtoIn personaDto);
        Task UpdatePersona(int id, PersonaDtoIn personaDto);
        Task Delete(int id);
    }
}
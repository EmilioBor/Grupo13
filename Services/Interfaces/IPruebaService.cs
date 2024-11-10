using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interfaces
{
    public interface IPruebaService
    {
        Task<IEnumerable<PruebaDtoOut>> GetAllPrueba();
        Task<PruebaDtoOut?> GetByIdPrueba(int id);
        Task<Prueba> CreatePrueba(PruebaDtoIn pruebaDto);
    }
}
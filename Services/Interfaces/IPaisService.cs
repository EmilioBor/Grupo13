using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisDtoOut>> GetAllPais();
        Task<PaisDtoOut?> GetByIdPais(int id);
        Task<Pais> CreatePais(PaisDtoIn paisDto);
    }
}
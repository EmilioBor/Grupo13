using Core.Request;
using Core.Response;
using Data.Models;
using System.Text.RegularExpressions;

namespace Services.Interfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisDtoOut>> GetAllPais();
        Task<PaisDtoOut?> GetByIdPais(int id);
        Task<Pais?> GetById(int id);
        Task<Pais> CreatePais(PaisDtoIn paisDto);
        Task UpdatePais(int id, PaisDtoIn paisDto);
        Task Delete(int id);
    }
}
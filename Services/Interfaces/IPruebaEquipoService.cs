using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interfaces
{
    public interface IPruebaEquipoService
    {
        Task<IEnumerable<PruebaEquipoDtoOut>> GetAllPruebaEquipo();
        Task<PruebaEquipoDtoOut?> GetByIdPruebaEquipo(int id);
        Task<PruebaEquipo> CreatePruebaEquipo(PruebaEquipoDtoIn pruebaEquipoDto);
    }
}
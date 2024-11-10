using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interfaces
{
    public interface IEquipoService
    {
        Task<IEnumerable<EquipoDtoOut>> GetAllEquipo();
        Task<EquipoDtoOut?> GetByIdEquipo(int id);
        Task<Equipo> CreateEquipo(EquipoDtoIn equipoDto);
    }
}
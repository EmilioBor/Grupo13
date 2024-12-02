using Core.Request;
using Core.Response;
using Data.Models;
using System.Text.RegularExpressions;

namespace Services.Interfaces
{
    public interface IEquipoService
    {
        Task<IEnumerable<EquipoDtoOut>> GetAllEquipo();
        Task<EquipoDtoOut?> GetByIdEquipo(int id);
        Task<Equipo?> GetById(int id);
        Task<Equipo> CreateEquipo(EquipoDtoIn equipoDto);
        Task UpdateEquipo(int id, EquipoDtoIn equipoDto);
        Task Delete(int id);
        Task<EquipoDtoOut?> GetByNombreEquipo(string nombre);
    }
}
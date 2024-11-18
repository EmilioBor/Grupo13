using Core.Request;
using Core.Response;
using Data.Models;
using System.Text.RegularExpressions;

namespace Services.Interfaces
{
    public interface IContratoService
    {
        Task<IEnumerable<ContratoDtoOut>> GetAllContrato();
        Task<ContratoDtoOut?> GetByIdContrato(int id);
        Task<Contrato?> GetById(int id);
        Task<Contrato> CreateContrato(ContratoDtoIn contratoDto);
        Task UpdateContrato(int id, ContratoDtoIn contratoDto);
        Task Delete(int id);
    }
}
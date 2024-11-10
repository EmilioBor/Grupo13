using Core.Request;
using Core.Response;
using Data.Models;

namespace Services.Interfaces
{
    public interface IContratoService
    {
        Task<IEnumerable<ContratoDtoOut>> GetAllContrato();
        Task<ContratoDtoOut?> GetByIdContrato(int id);
        Task<Contrato> CreateContrato(ContratoDtoIn contratoDto);
    }
}
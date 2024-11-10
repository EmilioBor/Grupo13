using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Service
{
    public class ContratoService : IContratoService
    {
        private readonly Grupo13Context _contex;
        public ContratoService(Grupo13Context contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<ContratoDtoOut>> GetAllContrato()
        {
            return await _contex.Contrato
                .Select(c => new ContratoDtoOut {

                    FechaFin = c.FechaFin,
                    FechaInicio = c.FechaInicio,
                    NombreEquipo = c.IdEquipoNavigation.Nombre,
                    NombrePersona = c.IdPersonaNavigation.Nombre

                 }).ToListAsync();
        }
        public async Task<ContratoDtoOut?> GetByIdContrato(int id)
        {
            return await _contex.Contrato
                .Where(c => c.Id == id)
                .Select(c => new ContratoDtoOut {

                    FechaFin = c.FechaFin,
                    FechaInicio = c.FechaInicio,
                    NombreEquipo = c.IdEquipoNavigation.Nombre,
                    NombrePersona = c.IdPersonaNavigation.Nombre

                }).SingleOrDefaultAsync();
        }

        public async Task<Contrato> CreateContrato(ContratoDtoIn contratoDto)
        {
            var newContrato = new Contrato();

            newContrato.FechaFin = contratoDto.FechaFin;
            newContrato.FechaInicio = contratoDto.FechaInicio;
            newContrato.IdEquipo = contratoDto.IdEquipo;
            newContrato.IdPersona = contratoDto.IdPersona;

            _contex.Contrato.Add(newContrato);
            await _contex.SaveChangesAsync();

            return newContrato;
        }
    }
}

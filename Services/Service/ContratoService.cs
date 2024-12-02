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
                    Id = c.Id,
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
                    Id = c.Id,
                    FechaFin = c.FechaFin,
                    FechaInicio = c.FechaInicio,
                    NombreEquipo = c.IdEquipoNavigation.Nombre,
                    NombrePersona = c.IdPersonaNavigation.Nombre

                }).SingleOrDefaultAsync();
        }
        public async Task<Contrato?> GetById(int id)
        {
            return await _contex.Contrato.FindAsync(id);
        }

        public async Task<IEnumerable<ContratoDtoOut?>> GetByEquipoContrato(string nombre)
        {
            return await _contex.Contrato
                .Where(c => c.IdEquipoNavigation.Nombre == nombre)
                .Select(c => new ContratoDtoOut
                {
                    Id = c.Id,
                    FechaFin = c.FechaFin,
                    FechaInicio = c.FechaInicio,
                    NombreEquipo = c.IdEquipoNavigation.Nombre,
                    NombrePersona = c.IdPersonaNavigation.Nombre + " " + c.IdPersonaNavigation.Apellido

                }).ToListAsync();
        }
        

        public async Task<Contrato> CreateContrato(ContratoDtoIn contratoDto)
        {
            if (contratoDto.FechaInicio > contratoDto.FechaFin || contratoDto.FechaInicio == contratoDto.FechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser mayor o igual que la fecha de fin.");
            }

            var newContrato = new Contrato();

            newContrato.FechaFin = contratoDto.FechaFin;
            newContrato.FechaInicio = contratoDto.FechaInicio;
            newContrato.IdEquipo = contratoDto.IdEquipo;
            newContrato.IdPersona = contratoDto.IdPersona;  
            

            _contex.Contrato.Add(newContrato);
            await _contex.SaveChangesAsync();

            return newContrato;
        }
        public async Task UpdateContrato(int id, ContratoDtoIn contratoDto)
        {
            var exis = await GetById(id);
            if( exis is not null)
            {
                exis.FechaInicio = contratoDto.FechaInicio;
                exis.FechaInicio = contratoDto.FechaInicio;
                exis.IdEquipo = contratoDto.IdEquipo;
                exis.IdPersona = contratoDto.IdPersona;


                await _contex.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ToDelete = await GetById(id);

            if (ToDelete is not null)
            {
                _contex.Contrato.Remove(ToDelete);
                await _contex.SaveChangesAsync();
            }
        }
    }
}

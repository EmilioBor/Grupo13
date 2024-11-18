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
    public class EquipoService : IEquipoService
    {
        private readonly Grupo13Context _contex;
        public EquipoService(Grupo13Context contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<EquipoDtoOut>> GetAllEquipo()
        {
            return await _contex.Equipo
                .Select(e => new EquipoDtoOut
                {

                    Nombre = e.Nombre,
                    NombrePais = e.IdPaisNavigation.Nombre,
                    NombrePersona = e.IdPersonaNavigation.Nombre

                }).ToListAsync();
        }
        public async Task<EquipoDtoOut?> GetByIdEquipo(int id)
        {
            return await _contex.Equipo
                .Where(e => e.Id == id)
                .Select(e => new EquipoDtoOut
                {

                    Nombre = e.Nombre,
                    NombrePais = e.IdPaisNavigation.Nombre,
                    NombrePersona = e.IdPersonaNavigation.Nombre

                }).SingleOrDefaultAsync();
        }

        public async Task<Equipo?> GetById(int id)
        {
            return await _contex.Equipo.FindAsync(id);
        }
        public async Task<Equipo> CreateEquipo(EquipoDtoIn equipoDto)
        {
            var newEquipo = new Equipo();

            newEquipo.Nombre = equipoDto.Nombre;
            newEquipo.IdPais = equipoDto.IdPais;
            newEquipo.IdPersona = equipoDto.IdPersona;

            _contex.Equipo.Add(newEquipo);
            await _contex.SaveChangesAsync();

            return newEquipo;
        }
        public async Task UpdateEquipo(int id,  EquipoDtoIn equipoDto)
        {
            var exist = await GetById(id);
            if (exist != null)
            {
                exist.Nombre = equipoDto.Nombre;
                exist.IdPais = equipoDto.IdPais;
                exist.IdPersona = equipoDto.IdPersona;

                await _contex.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ToDelete = await GetById(id);

            if (ToDelete is not null)
            {
                _contex.Equipo.Remove(ToDelete);
                await _contex.SaveChangesAsync();
            }
        }
    }
}

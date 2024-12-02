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
    public class PruebaEquipoService : IPruebaEquipoService
    {
        private readonly Grupo13Context _contex;
        public PruebaEquipoService(Grupo13Context contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<PruebaEquipoDtoOut>> GetAllPruebaEquipo()
        {
            return await _contex.PruebaEquipo
                .Select(p => new PruebaEquipoDtoOut
                {
                    Id = p.Id,
                    Posicion = p.Posicion,
                    NombreEquipo = p.IdEquipoNavigation.Nombre,
                    NombrePrueba = p.IdPruebaNavigation.Nombre
                }).ToListAsync();
        }
        public async Task<PruebaEquipoDtoOut?> GetByIdPruebaEquipo(int id)
        {
            return await _contex.PruebaEquipo
                .Where(p => p.Id == id)
                .Select(p => new PruebaEquipoDtoOut
                {
                    Id = p.Id,
                    Posicion = p.Posicion,
                    NombreEquipo = p.IdEquipoNavigation.Nombre,
                    NombrePrueba = p.IdPruebaNavigation.Nombre

                }).SingleOrDefaultAsync();
        }
        public async Task<PruebaEquipo?> GetById(int id)
        {
            return await _contex.PruebaEquipo.FindAsync(id);
        }

        public async Task<PruebaEquipo> CreatePruebaEquipo(PruebaEquipoDtoIn pruebaEquipoDto)
        {
            var newPruebaEquipo = new PruebaEquipo();

            newPruebaEquipo.Posicion = pruebaEquipoDto.Posicion;
            newPruebaEquipo.IdEquipo = pruebaEquipoDto.IdEquipo;
            newPruebaEquipo.IdPrueba = pruebaEquipoDto.IdPrueba;


            _contex.PruebaEquipo.Add(newPruebaEquipo);
            await _contex.SaveChangesAsync();

            return newPruebaEquipo;
        }
        public async Task UpdatePruebaEquipo(int id, PruebaEquipoDtoIn pruebaEquipoDto)
        {
            var exis = await GetById(id);
            if (exis != null)
            {
                exis.Posicion = pruebaEquipoDto.Posicion;
                exis.IdEquipo = pruebaEquipoDto.IdEquipo;
                exis.IdPrueba = pruebaEquipoDto.IdPrueba;

                await _contex.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ToDelete = await GetById(id);

            if (ToDelete is not null)
            {
                _contex.PruebaEquipo.Remove(ToDelete);
                await _contex.SaveChangesAsync();
            }
        }
    }
}

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

                    Posicion = p.Posicion,
                    NombreEquipo = p.IdEquipoNavigation.Nombre,
                    NombrePrueba = p.IdPruebaNavigation.Nombre

                }).SingleOrDefaultAsync();
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
    }
}

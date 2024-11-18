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
    public class PruebaService : IPruebaService
    {
        private readonly Grupo13Context _contex;
        public PruebaService(Grupo13Context contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<PruebaDtoOut>> GetAllPrueba()
        {
            return await _contex.Prueba
                .Select(p => new PruebaDtoOut
                {
                    Nombre = p.Nombre,
                    AñoEdicion = p.AñoEdicion,
                    CantEtapas = p.CantEtapas,
                    KmTotales = p.KmTotales,
                    NombrePersona = p.IdPersonaNavigation.Nombre

                }).ToListAsync();
        }
        public async Task<PruebaDtoOut?> GetByIdPrueba(int id)
        {
            return await _contex.Prueba
                .Where(p => p.Id == id)
                .Select(p => new PruebaDtoOut
                {

                    Nombre = p.Nombre,
                    AñoEdicion = p.AñoEdicion,
                    CantEtapas = p.CantEtapas,
                    KmTotales = p.KmTotales,
                    NombrePersona = p.IdPersonaNavigation.Nombre

                }).SingleOrDefaultAsync();
        }
        public async Task<Prueba?> GetById(int id)
        {
            return await _contex.Prueba.FindAsync(id);
        }

        public async Task<Prueba> CreatePrueba(PruebaDtoIn pruebaDto)
        {
            var newPrueba = new Prueba();

            newPrueba.Nombre = pruebaDto.Nombre;
            newPrueba.AñoEdicion = pruebaDto.AñoEdicion;
            newPrueba.CantEtapas = pruebaDto.CantEtapas;
            newPrueba.KmTotales = pruebaDto.KmTotales;
            newPrueba.IdPersona = pruebaDto.IdPersona;


            _contex.Prueba.Add(newPrueba);
            await _contex.SaveChangesAsync();

            return newPrueba;
        }
        public async Task UpdatePrueba(int id, PruebaDtoIn pruebaDto)
        {
            var exist = await GetById(id);
            if(exist != null)
            {
                exist.Nombre = pruebaDto.Nombre;
                exist.AñoEdicion = pruebaDto.AñoEdicion;
                exist.CantEtapas = pruebaDto.CantEtapas;
                exist.KmTotales = pruebaDto.KmTotales;
                exist.IdPersona = pruebaDto.IdPersona;
                await _contex.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ToDelete = await GetById(id);

            if (ToDelete is not null)
            {
                _contex.Prueba.Remove(ToDelete);
                await _contex.SaveChangesAsync();
            }
        }
    }
}

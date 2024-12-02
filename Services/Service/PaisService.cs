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
    public class PaisService : IPaisService
    {
        private readonly Grupo13Context _contex;
        public PaisService(Grupo13Context contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<PaisDtoOut>> GetAllPais()
        {
            return await _contex.Pais
                .Select(p => new PaisDtoOut
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                    

                }).ToListAsync();
        }
        public async Task<PaisDtoOut?> GetByIdPais(int id)
        {
            return await _contex.Pais
                .Where(p => p.Id == id)
                .Select(p => new PaisDtoOut
                {
                    Id = p.Id,
                    Nombre = p.Nombre  
                }).SingleOrDefaultAsync();
        }

        public async Task<Pais?> GetById(int id)
        {
            return await _contex.Pais.FindAsync(id);
        }

        public async Task<Pais> CreatePais(PaisDtoIn paisDto)
        {
            var newPais = new Pais();

            newPais.Nombre = paisDto.Nombre;

            _contex.Pais.Add(newPais);
            await _contex.SaveChangesAsync();

            return newPais;
        }
        public async Task UpdatePais(int id, PaisDtoIn paisDto)
        {
            var exist = await GetById(id);

            if (exist is not null)
            {
                exist.Nombre = paisDto.Nombre;
                await _contex.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ToDelete = await GetById(id);

            if (ToDelete is not null)
            {
                _contex.Pais.Remove(ToDelete);
                await _contex.SaveChangesAsync();
            }
        }
    }
}

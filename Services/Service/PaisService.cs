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

                    Nombre = p.Nombre
                    

                }).ToListAsync();
        }
        public async Task<PaisDtoOut?> GetByIdPais(int id)
        {
            return await _contex.Pais
                .Where(p => p.Id == id)
                .Select(p => new PaisDtoOut
                {
                    Nombre = p.Nombre
                    

                }).SingleOrDefaultAsync();
        }

        public async Task<Pais> CreatePais(PaisDtoIn paisDto)
        {
            var newPais = new Pais();

            newPais.Nombre = paisDto.Nombre;

            _contex.Pais.Add(newPais);
            await _contex.SaveChangesAsync();

            return newPais;
        }
    }
}

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
    public class PersonaService : IPersonaService
    {
        private readonly Grupo13Context _contex;
        public PersonaService(Grupo13Context contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<PersonaDtoOut>> GetAllPersona()
        {
            return await _contex.Persona
                .Select(p => new PersonaDtoOut
                {
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Dni = p.Dni,
                    FechaNacimiento = p.FechaNacimiento,
                    NombrePais = p.IdPaisNavigation.Nombre

                }).ToListAsync();
        }
        public async Task<PersonaDtoOut?> GetByIdPersona(int id)
        {
            return await _contex.Persona
                .Where(p => p.Id == id)
                .Select(p => new PersonaDtoOut
                {

                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Dni = p.Dni,
                    FechaNacimiento = p.FechaNacimiento,
                    NombrePais = p.IdPaisNavigation.Nombre

                }).SingleOrDefaultAsync();
        }

        public async Task<Persona> CreatePersona(PersonaDtoIn personaDto)
        {
            var newPersona = new Persona();

            newPersona.Nombre = personaDto.Nombre;
            newPersona.Apellido = personaDto.Apellido;
            newPersona.Dni = personaDto.Dni;
            newPersona.FechaNacimiento = personaDto.FechaNacimiento;
            newPersona.IdPais = personaDto.IdPais;
            

            _contex.Persona.Add(newPersona);
            await _contex.SaveChangesAsync();

            return newPersona;
        }
    }
}

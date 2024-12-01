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
                    NombrePais = p.IdPaisNavigation.Nombre,
                    Rol = p.Rol

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
                    NombrePais = p.IdPaisNavigation.Nombre,
                    Rol = p.Rol

                }).SingleOrDefaultAsync();
        }

        public async Task<Persona?> GetById(int id)
        {
            return await _contex.Persona.FindAsync(id);
        }

        public async Task<Persona> CreatePersona(PersonaDtoIn personaDto)
        {
            var newPersona = new Persona();

            newPersona.Nombre = personaDto.Nombre;
            newPersona.Apellido = personaDto.Apellido;
            newPersona.Dni = personaDto.Dni;
            newPersona.FechaNacimiento = personaDto.FechaNacimiento;
            newPersona.IdPais = personaDto.IdPais;
            newPersona.Rol = personaDto.Rol;
            

            _contex.Persona.Add(newPersona);
            await _contex.SaveChangesAsync();

            return newPersona;
        }

        public async Task UpdatePersona(int id, PersonaDtoIn personaDto)
        {
            var exist = await GetById(id);

            if (exist is not null)
            {
                exist.Nombre = personaDto.Nombre;
                exist.Apellido = personaDto.Apellido;
                exist.Dni = personaDto.Dni;
                exist.FechaNacimiento = personaDto.FechaNacimiento;
                exist.IdPais = personaDto.IdPais;
                exist.Rol = personaDto.Rol;

                await _contex.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ToDelete = await GetById(id);

            if (ToDelete is not null)
            {
                _contex.Persona.Remove(ToDelete);
                await _contex.SaveChangesAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class PersonaDtoOut
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int Dni { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string? NombrePais { get; set; }
        public bool Rol { get; set; }
    }
}

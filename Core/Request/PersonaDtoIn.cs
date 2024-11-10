using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class PersonaDtoIn
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int Dni { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int IdPais { get; set; }
    }
}

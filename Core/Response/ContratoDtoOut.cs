using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class ContratoDtoOut
    {
        public int Id { get; set; }
        public DateTime FechaFin { get; set; }

        public DateTime FechaInicio { get; set; }

        public string? NombrePersona { get; set; }

        public string? NombreEquipo { get; set; }
    }
}

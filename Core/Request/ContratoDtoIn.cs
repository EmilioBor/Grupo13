using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class ContratoDtoIn
    {
        public int Id { get; set; }

        public DateTime FechaFin { get; set; }

        public DateTime FechaInicio { get; set; }

        public int IdPersona { get; set; }

        public int IdEquipo { get; set; }
    }
}

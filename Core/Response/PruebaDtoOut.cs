using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class PruebaDtoOut
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int AñoEdicion { get; set; }

        public int CantEtapas { get; set; }

        public float KmTotales { get; set; }

        public string? NombrePersona { get; set; }
    }
}

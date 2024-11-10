using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class EquipoDtoIn
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int IdPais { get; set; }

        public int IdPersona { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickingAPPApi.Models
{
    public class OlaModels
    {
        public int numero_ola { get; set; }
        public DateTime fecha_picking { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string estado { get; set; }
    }
}

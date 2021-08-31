using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickingAPPApi.Models
{
    public class ProductModels
    {
        public string sku { get; set; }
        public int cantidad { get; set; }

        public string codigo_barra { get; set; }

        public string descripcion { get; set; }

        public string order_id { get; set; }

        public string quantity_check { get; set; }

        public string quantity_picking { get; set; }

    }
}

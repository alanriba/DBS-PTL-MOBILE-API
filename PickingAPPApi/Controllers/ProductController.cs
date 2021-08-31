using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PickingAPPApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickingAPPApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private string _conn = @"Server=207.246.78.100; Database=oc; Uid=Dbs.2014,; Pwd=P4dYyCv9ew9wnxQe";
        // private string _conn = @"Server=207.246.78.100; Database=oc3; Uid=tienda3; Pwd=r2x2hiy2";
        [HttpGet]
        public IActionResult GetOla(int idOla)
        {
            IEnumerable<ProductModels> lst = null;

            var sql = @"select p.model as SKU,sum(p.quantity) as cantidad, p.codigo_barra,  p.`name` as descripcion, p.order_id, p.quantity_check, p.quantity_picking" +
" from oc_order_product p " +
" INNER JOIN oc_order_picking_pedidos pe on pe.order_id = p.order_id" +
" WHERE pe.order_picking_id = " + idOla + "" +
" and p.model != 'DBS-050'" +
" GROUP BY p.model order by p.model asc";
            using (var db = new MySqlConnection(_conn))
            {
                lst = db.Query<ProductModels>(sql);

            }
            return Ok(lst);
        }



        [HttpGet]
        [Route("update")]
        public IActionResult PutProduct(int orderId, string cBarra, string status, string quantity)
        {
            int result = 0;
            var sql = @"update oc_order_product set quantity_picking = '"+ status+ "' , quantity_check='" + quantity + "'" +
                       " where order_id = '" + orderId + "' AND codigo_barra='"+cBarra+"'";
            using (var db = new MySqlConnection(_conn))
            {
                result = db.Execute(sql);

            }
            return Ok(result);
        }
    }
}

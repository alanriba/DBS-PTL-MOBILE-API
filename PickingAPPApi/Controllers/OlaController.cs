using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PickingAPPApi.Models;
using System.Collections.Generic;

namespace PickingAPPApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OlaController : Controller
    {

       private string _conn = @"Server=207.246.78.100; Database=oc; Uid=Dbs.2014,; Pwd=P4dYyCv9ew9wnxQe";
       // private string _conn = @"Server=207.246.78.100; Database=oc3; Uid=tienda3; Pwd=r2x2hiy2";

        [HttpGet]

        public IActionResult GetOla(int idPicking)
        {
            IEnumerable<OlaModels> lst = null;

            var sql = @"select p.order_picking_id as numero_ola , date(p.date_added) as fecha_picking,  u.firstname as nombre ,u.lastname as apellido, s.name as estado" +
" from oc_order_picking p " +
" INNER JOIN oc_user u on u.user_id = p.id_pickeador" +
" INNER JOIN oc_order_picking_status s on s.order_picking_status_id = p.order_picking_status_id" +
" WHERE u.picking_code = " + idPicking + "" +
" and p.date_added BETWEEN DATE_SUB(NOW(), INTERVAL 2 MONTH) AND NOW()" +
" order by p.order_picking_status_id ASC, p.date_added DESC";
            using (var db = new MySqlConnection(_conn))
            {
                lst = db.Query<OlaModels>(sql);

            }
            return Ok(lst);
        }

        [HttpGet]
        [Route("update")]
        public IActionResult PutOla(int idOla)
        {
            int result = 0;
            var sql = @"update oc_order_picking set order_picking_status_id = 3, date_modified = now()" +
                       " where order_picking_id = '"+idOla+"'";
            using (var db = new MySqlConnection(_conn))
            {
                result = db.Execute(sql);

            }
            return Ok(result);
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO
{
    public class Detalle_VentaDTO
    {
        public int IdProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set;}
        public int Total { get; set;}
    }
}

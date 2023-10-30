using Api.Web.WebApi.Models.DBVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
    }
}

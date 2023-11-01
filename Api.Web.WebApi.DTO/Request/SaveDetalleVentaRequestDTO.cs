using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Request
{
    public class SaveDetalleVentaRequestDTO
    {

        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}

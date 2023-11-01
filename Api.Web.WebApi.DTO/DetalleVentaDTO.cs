using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO
{
    public class DetalleVentaDTO
    {
        public int IdVenta { get; set; }
        public string TipoPago { get; set; }
        public string NumeroDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPagoCon { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoSubTotal { get; set; }
        public decimal MontoIGV { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdDetalleVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public string DescripcionProducto { get; set; }
        public string DescripcionCategoria { get; set; }


    }
}

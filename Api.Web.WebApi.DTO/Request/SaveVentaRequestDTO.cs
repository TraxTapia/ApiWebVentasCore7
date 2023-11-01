using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Request
{
    public class SaveVentaRequestDTO
    {
        public string TipoPago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPagoCon { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoSubTotal { get; set; }
        public decimal MontoIGV { get; set; }
        public decimal MontoTotal { get; set; }
        public List<Detalle_VentaDTO> DetalleVenta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Models.DBVenta
{
    [Table("Detalle_Venta")]
    public partial class Detalle_Venta
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public int? IdVenta { get; set; }

        public int? IdProducto { get; set; }

        public decimal PrecioVenta { get; set; }

        public int Cantidad { get; set; }

        public decimal Total { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }
    }
}

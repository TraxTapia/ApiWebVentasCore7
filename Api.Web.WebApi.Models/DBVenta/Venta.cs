using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Models.DBVenta
{

    [Table("Venta")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            Detalle_Venta = new HashSet<Detalle_Venta>();
        }

        [Key]
        public int IdVenta { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoPago { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string DocumentoCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCliente { get; set; }

        public decimal MontoPagoCon { get; set; }

        public decimal MontoCambio { get; set; }

        public decimal MontoSubTotal { get; set; }

        public decimal MontoIGV { get; set; }

        public decimal MontoTotal { get; set; }

        public DateTime? FechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Venta> Detalle_Venta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Models.DBVenta
{
    [Table("Producto")]
    public partial class Producto
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Producto()
        //{
        //    Detalle_Venta = new HashSet<Detalle_Venta>();
        //}

        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(100)]
        public string Codigo { get; set; }
 
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public decimal PrecioCompra { get; set; }

        public decimal PrecioVenta { get; set; }

        public int Stock { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool Activo { get; set; }
        //[ForeignKey("IdCategoria")]
        //public virtual Categoria Categoria { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Detalle_Venta> Detalle_Venta { get; set; }
    }
}

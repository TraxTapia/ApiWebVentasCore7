using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Models.DBVenta
{
    [Table("CATEGORIA")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public DateTime? FechaRegistro { get; set; }
        //[ForeignKey("IdCategoria")]
        //public Producto oProducto { get; set; }
    }
}

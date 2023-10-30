using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Models.DBVenta
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required]
        [StringLength(100)]
        public string Clave { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool Activo { get; set; }
    }
}

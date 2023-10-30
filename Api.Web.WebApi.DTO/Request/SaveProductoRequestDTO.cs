using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Request
{
    public class SaveProductoRequestDTO
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Se encontraron valores negativos en el campo IdCategoria")]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "No se pueden agregar mas de 100 caracteres en el campo Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        public decimal PrecioCompra { get; set; }
        [Required]
        public decimal PrecioVenta { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Se encontraron valores negativos en el campo Stock")]
        public int Stock { get; set; }
    }
}

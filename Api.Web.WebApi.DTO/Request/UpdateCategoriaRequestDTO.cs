using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Request
{
    public class UpdateCategoriaRequestDTO
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}

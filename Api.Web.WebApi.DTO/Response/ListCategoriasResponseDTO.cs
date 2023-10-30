using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Response
{
    public class ListCategoriasResponseDTO
    {
        public ListCategoriasResponseDTO()
        {
            this.Result = new OperationResult.OperationResult();
            this.Items = new List<CategoriaDTO>();
        }
        public List<CategoriaDTO> Items { get; set; }
        public OperationResult.OperationResult Result { get; set; }
    }
}

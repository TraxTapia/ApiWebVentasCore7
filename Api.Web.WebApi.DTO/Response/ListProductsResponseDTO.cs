using Api.Web.WebApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Response
{
    public  class ListProductsResponseDTO
    {
        public ListProductsResponseDTO()
        {
            this.Result = new OperationResult.OperationResult();
            this.Items = new List<ProductoDTO>();
        }
        public List<ProductoDTO> Items { get; set; }
        public OperationResult.OperationResult Result { get; set; }
    }
}

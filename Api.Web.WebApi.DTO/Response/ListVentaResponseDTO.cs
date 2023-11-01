using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Response
{
    public  class ListVentaResponseDTO
    {
        public ListVentaResponseDTO()
        {
            this.Result = new OperationResult.OperationResult();
            this.Items = new List<DetalleVentaDTO>();
        }
        public OperationResult.OperationResult Result { get; set; }
        public List<DetalleVentaDTO> Items { get; set; }


    }
}

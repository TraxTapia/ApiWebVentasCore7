using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Response
{
    public class RegistroVentaResponseDTO
    {
        public RegistroVentaResponseDTO()
        {
            this.Result = new OperationResult.OperationResult();
            this.NroDocumento = string.Empty;
        }
        public string NroDocumento { get; set; }
        public OperationResult.OperationResult Result { get; set; }
    }
}

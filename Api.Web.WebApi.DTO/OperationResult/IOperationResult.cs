using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.OperationResult
{
    public class IOperationResult
    {
        private string code = string.Empty;
        private string message = string.Empty;

        public string Code { get => code; set => code = value; }
        public string Message { get => message; set => message = value; }
    }
}

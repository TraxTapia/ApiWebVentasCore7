using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Response.Token
{
    public class TokenResponseDTO
    {
        public TokenResponseDTO()
        {
            this.Result = new OperationResult.OperationResult();
            this.AccessToken = String.Empty;
            this.TokenType = String.Empty;
            this.ExpiresIn = 0;
            this.Username = String.Empty;
            this.ExpiresAt = String.Empty;
        }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public string Username { get; set; }
        public string ExpiresAt { get; set; }
        public OperationResult.OperationResult Result { get; set; }
    }
}

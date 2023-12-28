using Api.Web.WebApi.DTO.DTOApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.DTO.Response
{
    public class ListAutocompleteResponseDTO
    {
        public ListAutocompleteResponseDTO()
        {
            this.Autocomplete = new List<AutocompleteDTO>();
            this.Result = new OperationResult.OperationResult();
        }
        public OperationResult.OperationResult Result { get; set; }
        public List<AutocompleteDTO> Autocomplete { get; set; }
    }
}

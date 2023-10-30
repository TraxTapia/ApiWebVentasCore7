using Api.Web.WebApi.Models.DBVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Web.WebApi.DTO.Response;
using Api.Web.WebApi.DTO.Request;
using Api.Web.WebApi.DTO.OperationResult;

namespace Api.Web.WebApi.Infrastructure.Interfaces
{
    public interface IServicesGeneric
    {
        Task<ListProductsResponseDTO> GetProducts();
        Task<OperationResult> SaveProducto(SaveProductoRequestDTO _Request);
        Task<OperationResult> UpdateProducto(UpdateProductoRequestDTO _Request);
    }
}

using Api.Web.WebApi.DTO;
using Api.Web.WebApi.DTO.OperationResult;
using Api.Web.WebApi.DTO.Response;
using Api.Web.WebApi.Models.DBVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Infrastructure.Interfaces
{
    public interface IRepositoryGeneric
    {
        Task<List<ProductoDTO>> GetAllProductos();
        Task<OperationResult> SaveProduct(Producto _Request);
        Task<Producto> GetProductById(int Id);
        Task<OperationResult> UpdateProduct(Producto _Request);
        Task<OperationResult> DeleteProduct(Producto _Request);
        Task<List<Categoria>> GetAllCategorias();
        Task<OperationResult> SaveCategoria(Categoria _Request);
        Task<Categoria> GetByIdCategoria(int Id);
        Task<OperationResult> UpdateCategoria(Categoria _Request);
        Task<OperationResult> DeleteCategoria(Categoria _Request);

    }
}

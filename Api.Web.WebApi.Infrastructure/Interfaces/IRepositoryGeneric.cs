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
        //Task Add<T>(T entity) where T :class;
        Task<OperationResult> SaveProduct(Producto _Request);
        //Task<List<Producto>> GetAllProducts();
        //Task<List<Categoria>> GetAllCategoria();
    }
}

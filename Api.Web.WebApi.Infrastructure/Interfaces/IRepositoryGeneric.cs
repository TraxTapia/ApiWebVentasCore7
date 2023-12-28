using Api.Web.WebApi.DTO;
using Api.Web.WebApi.DTO.OperationResult;
using Api.Web.WebApi.DTO.Request;
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
        #region Productos
        Task<List<ProductoDTO>> GetAllProductos();
        List<ProductoDTO> GetProductos();
        Task<OperationResult> SaveProduct(Producto _Request);
        Task<Producto> GetProductById(int Id);
        Task<OperationResult> UpdateProduct(Producto _Request);
        Task<OperationResult> DeleteProduct(Producto _Request);
        #endregion
        #region Categoria 
        Task<List<Categoria>> GetAllCategorias();
        Task<OperationResult> SaveCategoria(Categoria _Request);
        Task<Categoria> GetByIdCategoria(int Id);
        Task<OperationResult> UpdateCategoria(Categoria _Request);
        Task<OperationResult> DeleteCategoria(Categoria _Request);
        #endregion
        #region Venta & Detalle Venta
        Task<List<DetalleVentaDTO>> GetDetalleVentaByCodeDocument(string _NroDocumento);
        Task<RegistroVentaResponseDTO> RegisterVentas(SaveVentaRequestDTO _Request);
        #endregion

    }
}

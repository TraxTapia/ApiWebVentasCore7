using Api.Web.WebApi.DTO;
using Api.Web.WebApi.DTO.OperationResult;
using Api.Web.WebApi.DTO.Request;
using Api.Web.WebApi.DTO.Response;
using Api.Web.WebApi.Infrastructure.Interfaces;
using Api.Web.WebApi.Models.DBVenta;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Infrastructure.Repository
{
    public class RepositoryGeneric : IRepositoryGeneric
    {
        protected readonly DBContextVenta _dbContext;
        public RepositoryGeneric(DBContextVenta contextVenta)
        {
            _dbContext = contextVenta;
        }
        #region Productos
        public async Task<List<ProductoDTO>> GetAllProductos()
        {
            return await (from a in _dbContext.Producto
                          join b in _dbContext.Categoria on a.IdCategoria equals b.IdCategoria
                          select new ProductoDTO()
                          {
                              IdProducto = a.IdProducto,
                              Codigo = a.Codigo,
                              IdCategoria = a.IdCategoria,
                              Categoria = b.Descripcion,
                              Descripcion = a.Descripcion,
                              PrecioCompra = a.PrecioCompra,
                              PrecioVenta = a.PrecioVenta,
                              Stock = a.Stock,
                          }).ToListAsync();
        }
        public async Task<OperationResult> SaveProduct(Producto _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                await _dbContext.Producto.AddAsync(_Request);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _Response;
        }
        public async Task<Producto> GetProductById(int Id)
        {
            return await _dbContext.Producto.AsNoTracking().FirstOrDefaultAsync(x => x.IdProducto == Id);
        }
        public async Task<OperationResult> UpdateProduct(Producto _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _dbContext.Producto.Update(_Request);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _Response;
        }
        public async Task<OperationResult> DeleteProduct(Producto _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _dbContext.Producto.Update(_Request);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _Response;
        }
        #endregion
        #region Categoria 
        public async Task<List<Categoria>> GetAllCategorias()
        {
            return await _dbContext.Categoria.AsNoTracking().ToListAsync();
        }
        public async Task<OperationResult> SaveCategoria(Categoria _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                await _dbContext.Categoria.AddAsync(_Request);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _Response;
        }
        public async Task<Categoria> GetByIdCategoria(int Id)
        {
            return await _dbContext.Categoria.AsNoTracking().FirstOrDefaultAsync(x => x.IdCategoria == Id);
        }
        public async Task<OperationResult> UpdateCategoria(Categoria _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _dbContext.Categoria.Update(_Request);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _Response;
        }
        public async Task<OperationResult> DeleteCategoria(Categoria _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _dbContext.Categoria.Update(_Request);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _Response;
        }
        #endregion

        #region Venta & Detalle Venta
        public async Task<List<DetalleVentaDTO>> GetDetalleVentaByCodeDocument(string _NroDocumento)
        {
            List<DetalleVentaDTO> _Response = new List<DetalleVentaDTO>();
            try
            {
                _Response = await (from v in _dbContext.Venta
                                   join dv in _dbContext.Detalle_Venta on v.IdVenta equals dv.IdVenta
                                   join p in _dbContext.Producto on dv.IdProducto equals p.IdProducto
                                   join c in _dbContext.Categoria on p.IdCategoria equals c.IdCategoria
                                   where v.NumeroDocumento == _NroDocumento.Trim()
                                   select new DetalleVentaDTO()
                                   {
                                       IdVenta = v.IdVenta,
                                       TipoPago = v.TipoPago,
                                       NumeroDocumento = v.NumeroDocumento,
                                       DocumentoCliente = v.DocumentoCliente,
                                       NombreCliente = v.NombreCliente,
                                       MontoPagoCon = v.MontoPagoCon,
                                       MontoCambio = v.MontoCambio,
                                       MontoSubTotal = v.MontoSubTotal,
                                       MontoIGV = v.MontoIGV,
                                       MontoTotal = v.MontoTotal,
                                       FechaRegistro = v.FechaRegistro ?? default(DateTime),
                                       IdDetalleVenta = dv.IdDetalleVenta,
                                       IdProducto = p.IdProducto,
                                       PrecioVenta = dv.PrecioVenta,
                                       Cantidad = dv.Cantidad,
                                       Total = dv.Total,
                                       DescripcionProducto = p.Descripcion,
                                       DescripcionCategoria = c.Descripcion,

                                   }).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return _Response;
        }
        public async Task<RegistroVentaResponseDTO> RegisterVentas(SaveVentaRequestDTO _Request)
        {
            RegistroVentaResponseDTO _Response = new RegistroVentaResponseDTO();
            try
            {
                var _IdUltimo = await this.GetTheLastRecord();
                if (_IdUltimo != 0)
                {
                    Venta _SaveVenta = new Venta()
                    {
                        TipoPago = _Request.TipoPago,
                        NumeroDocumento =string.Concat(_IdUltimo.ToString().PadLeft(5)),
                        DocumentoCliente = _Request.DocumentoCliente,
                        NombreCliente = _Request.NombreCliente,
                    };
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<int> GetTheLastRecord()
        {
            int _Id;
            var Data = await _dbContext.Venta.OrderByDescending(x => x.IdVenta).FirstOrDefaultAsync();
            if (Data == null)
            {
                return 0;
            }
            _Id = Data.IdVenta;
            return _Id;
        }
        #endregion

    }
}

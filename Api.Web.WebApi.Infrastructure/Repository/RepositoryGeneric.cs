using Api.Web.WebApi.DTO;
using Api.Web.WebApi.DTO.OperationResult;
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
        public RepositoryGeneric()
        {

        }
        public RepositoryGeneric(DBContextVenta contextVenta)
        {
            _dbContext = contextVenta;
        }
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

    }
}

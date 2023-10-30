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
        //public async Task Add<T>(T entity) where T : class
        //{
        //    //await _dbContext.Set<T>().AddAsync(entity);
        //    //await _dbContext.SaveChangesAsync();

        //    try
        //    {

        //        await _dbContext.Set<T>().AddAsync(entity);
        //        await _dbContext.SaveChangesAsync();


        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción aquí
        //        throw new Exception(ex.Message);
        //    }
        //}
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


        //public async Task<List<Producto>> GetAllProducts()
        //{
        //    return await _dbContext.Producto
        //        .ToListAsync();
        //}
        //public async Task<List<Categoria>> GetAllCategoria()
        //{
        //    return await _dbContext.Categoria
        //        .ToListAsync();
        //}

    }
}

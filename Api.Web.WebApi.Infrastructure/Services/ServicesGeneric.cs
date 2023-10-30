using Api.Web.WebApi.Infrastructure.Interfaces;
using Api.Web.WebApi.Models.DBVenta;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Web.WebApi.Utilities.Logger;
using Api.Web.WebApi.DTO.Response;
using Api.Web.WebApi.DTO.OperationResult;
using Api.Web.WebApi.DTO;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using Api.Web.WebApi.DTO.Request;
using System.Runtime.InteropServices;
using Api.Web.WebApi.Utilities.Utilities;
using Api.Web.WebApi.Infrastructure.Repository;

namespace Api.Web.WebApi.Infrastructure.Services
{
    public class ServicesGeneric : IServicesGeneric
    {
        public IRepositoryGeneric _Repo;
        private readonly Logger _Logger;
        private readonly IConfiguration _Configuration;
        protected readonly DBContextVenta _dbContext;

        public ServicesGeneric(IRepositoryGeneric _Repository, IConfiguration Configuration, DBContextVenta contextVenta)
        {
            this._Repo = _Repository;
            this._Configuration = Configuration;
            this._Logger = new Logger(Configuration["EnvApp:LogPath"]);
            _dbContext = contextVenta;

        }
        public async Task<ListProductsResponseDTO> GetProducts()
        {
            ListProductsResponseDTO _Response = new ListProductsResponseDTO();
            try
            {
                _Response.Items = await _Repo.GetAllProductos();
                if (!_Response.Items.Any())
                {
                    _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                    _Response.Result.AddException(new Exception("No se encontraron resultados."));
                    return _Response;
                }
            }
            catch (Exception ex)
            {
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
                throw new Exception(ex.Message);
            }

            return _Response;
        }
        public async Task<OperationResult> SaveProducto(SaveProductoRequestDTO _Request)
        {
            OperationResult _Response = new OperationResult();
            UtilitiesGeneric _Utilities = new UtilitiesGeneric();
            RepositoryGeneric _Repo = new RepositoryGeneric(_dbContext);
            //RepositoryGeneric _Repo = new RepositoryGeneric();
            try
            {
                Producto _SaveProducto = new Producto()
                {
                    Codigo = _Utilities.GenerateCode(),
                    IdCategoria = _Request.IdCategoria,
                    Descripcion = _Request.Descripcion.Trim(),
                    PrecioCompra = _Request.PrecioCompra,
                    PrecioVenta = _Request.PrecioVenta,
                    Stock = _Request.Stock,
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };
                await _Repo.SaveProduct(_SaveProducto);
            }
            catch (Exception ex)
            {
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
                throw new Exception(ex.Message);
            }
            return _Response;

        }
        public async Task<OperationResult> UpdateProducto(UpdateProductoRequestDTO _Request)
        {
            OperationResult _Response = new OperationResult();
            UtilitiesGeneric _Utilities = new UtilitiesGeneric();
            RepositoryGeneric _Repo = new RepositoryGeneric(_dbContext);
            try
            {
                var _Data = await _Repo.GetProductById(_Request.IdProducto);
                if (_Data == null)
                {
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                    _Response.AddException(new Exception("No se encontraron resultados."));
                    return _Response;
                }


                _Data.IdCategoria = _Request.IdCategoria;
                _Data.Descripcion = _Request.Descripcion.Trim();
                _Data.PrecioCompra = _Request.PrecioCompra;
                _Data.PrecioVenta = _Request.PrecioVenta;
                _Data.Stock = _Request.Stock;

                await _Repo.UpdateProduct(_Data);
            }
            catch (Exception ex)
            {
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
                throw new Exception(ex.Message);
            }
            return _Response;

        }
        public async Task<OperationResult> DeleteProduct(int _IdProducto)
        {
            OperationResult _Response = new OperationResult();
            UtilitiesGeneric _Utilities = new UtilitiesGeneric();
            RepositoryGeneric _Repo = new RepositoryGeneric(_dbContext);
            try
            {
                var _Data = await _Repo.GetProductById(_IdProducto);
                if (_Data == null)
                {
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                    _Response.AddException(new Exception("No se encontraron resultados a eliminar."));
                    return _Response;
                }
                _Data.Activo = false;
                

                await _Repo.UpdateProduct(_Data);
            }
            catch (Exception ex)
            {
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
                throw new Exception(ex.Message);
            }
            return _Response;

        }

        public async Task<ListCategoriasResponseDTO> GetCategorias()
        {
            ListCategoriasResponseDTO _Response = new ListCategoriasResponseDTO();
            try
            {
               var _Data = await _Repo.GetAllCategorias();
                if (!_Data.Any())
                {
                    _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                    _Response.Result.AddException(new Exception("No se encontraron resultados."));
                    return _Response;
                }
                _Response.Items = _Data.Select(x => new CategoriaDTO()
                {
                    IdCategoria = x.IdCategoria,
                    Descripcion = x.Descripcion.Trim(),
                    Activo = x.Activo

                }).ToList();
            }
            catch (Exception ex)
            {
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
                throw new Exception(ex.Message);
            }

            return _Response;

        }
        public async Task<OperationResult> SaveCategoria(string _Descripcion)
        {
            OperationResult _Response = new OperationResult();
            UtilitiesGeneric _Utilities = new UtilitiesGeneric();
            RepositoryGeneric _Repo = new RepositoryGeneric(_dbContext);
            try
            {
                Categoria _SaveCategoria = new Categoria()
                {
                    Descripcion = _Descripcion.Trim(),
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };
                await _Repo.SaveCategoria(_SaveCategoria);
            }
            catch (Exception ex)
            {
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
                throw new Exception(ex.Message);
            }
            return _Response;

        }
        public async Task<OperationResult> UpdateCategoria(UpdateCategoriaRequestDTO _Request)
        {
            OperationResult _Response = new OperationResult();
            UtilitiesGeneric _Utilities = new UtilitiesGeneric();
            RepositoryGeneric _Repo = new RepositoryGeneric(_dbContext);
            try
            {
                var _Data = await _Repo.GetByIdCategoria(_Request.IdCategoria);
                if (_Data == null)
                {
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                    _Response.AddException(new Exception("No se encontraron resultados."));
                    return _Response;
                }
                _Data.Descripcion = _Request.Descripcion.Trim();

                await _Repo.UpdateCategoria(_Data);
            }
            catch (Exception ex)
            {
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
                throw new Exception(ex.Message);
            }
            return _Response;

        }
        public async Task<OperationResult> DeleteCategoria(int _IdCategoria)
        {
            OperationResult _Response = new OperationResult();
            UtilitiesGeneric _Utilities = new UtilitiesGeneric();
            RepositoryGeneric _Repo = new RepositoryGeneric(_dbContext);
            try
            {
                var _Data = await _Repo.GetByIdCategoria(_IdCategoria);
                if (_Data == null)
                {
                    _Response.SetStatusCode(OperationResult.StatusCodesEnum.NOT_FOUND);
                    _Response.AddException(new Exception("No se encontraron resultados a eliminar."));
                    return _Response;
                }
                _Data.Activo = false;
                await _Repo.UpdateCategoria(_Data);
            }
            catch (Exception ex)
            {
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
                throw new Exception(ex.Message);
            }
            return _Response;

        }
    }
}

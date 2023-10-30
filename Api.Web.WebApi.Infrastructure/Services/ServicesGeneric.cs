﻿using Api.Web.WebApi.Infrastructure.Interfaces;
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
    public class ServicesGeneric: IServicesGeneric
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

    }
}

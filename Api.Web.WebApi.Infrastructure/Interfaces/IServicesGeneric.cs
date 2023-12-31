﻿using Api.Web.WebApi.Models.DBVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Web.WebApi.DTO.Response;
using Api.Web.WebApi.DTO.Request;
using Api.Web.WebApi.DTO.OperationResult;
using Api.Web.WebApi.DTO;
using Api.Web.WebApi.Infrastructure.Repository;
using Api.Web.WebApi.Utilities.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Api.Web.WebApi.Infrastructure.Interfaces
{
    public interface IServicesGeneric
    {
        #region Productos
        Task<ListProductsResponseDTO> GetProducts();
        Task<OperationResult> SaveProducto(SaveProductoRequestDTO _Request);
        Task<OperationResult> UpdateProducto(UpdateProductoRequestDTO _Request);
        Task<OperationResult> DeleteProduct(int _IdProducto);
        #endregion
        #region Categoria 
        Task<ListCategoriasResponseDTO> GetCategorias();
        Task<OperationResult> SaveCategoria(string _Descripcion);
        Task<OperationResult> UpdateCategoria(UpdateCategoriaRequestDTO _Request);
        Task<OperationResult> DeleteCategoria(int _IdCategoria);
        #endregion
        #region Venta & Detalle Venta
        Task<ListVentaResponseDTO> GetVentaByNroDocumento(string _NroDocumento);
        Task<RegistroVentaResponseDTO> RegisterVentas(SaveVentaRequestDTO _Request);
        #endregion
        #region Filtros 
        public ListAutocompleteResponseDTO Autocomplete(string _Search);
        #endregion
    }
}

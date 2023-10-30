using Api.Web.WebApi.DTO.OperationResult;
using Api.Web.WebApi.DTO.Request;
using Api.Web.WebApi.DTO.Response;
using Api.Web.WebApi.Infrastructure.Interfaces;
using Api.Web.WebApi.Utilities.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaWebController : ControllerBase
    {
        private readonly IServicesGeneric _IServicesGeneric;
        private readonly IConfiguration Configuration;
        private readonly Logger _Logger;
        public SistemaWebController(IServicesGeneric SinisterService, IConfiguration Configuration)
        {
            this._IServicesGeneric = SinisterService;
            this.Configuration = Configuration;
            this._Logger = new Logger(Configuration["EnvApp:LogPath"]);
        }

        [HttpGet, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/GetProducts")]
        public async Task<ListProductsResponseDTO> GetProducts()
        {
            ListProductsResponseDTO _Response = new ListProductsResponseDTO();
            try
            {
                _Response = await _IServicesGeneric.GetProducts();
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
            }
            return _Response;
        }
        [HttpPost, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/SaveProducto")]
        public async Task<OperationResult> SaveProducto(SaveProductoRequestDTO _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _Response = await _IServicesGeneric.SaveProducto(_Request);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }

        [HttpPost, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/UpdateProducto")]
        public async Task<OperationResult> UpdateProducto(UpdateProductoRequestDTO _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _Response = await _IServicesGeneric.UpdateProducto(_Request);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }

        [HttpPost, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/DeleteProduct")]
        public async Task<OperationResult> DeleteProduct([FromBody]int _IdProducto)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _Response = await _IServicesGeneric.DeleteProduct(_IdProducto);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }

        [HttpGet, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/GetCategorias")]
        public async Task<ListCategoriasResponseDTO> GetCategorias()
        {
            ListCategoriasResponseDTO _Response = new ListCategoriasResponseDTO();
            try
            {
                _Response = await _IServicesGeneric.GetCategorias();
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
            }
            return _Response;
        }

        [HttpPost, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/SaveCategoria")]
        public async Task<OperationResult> SaveCategoria([FromBody] string _Descripcion)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _Response = await _IServicesGeneric.SaveCategoria(_Descripcion);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }

        [HttpPost, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/UpdateCategoria")]
        public async Task<OperationResult> UpdateCategoria(UpdateCategoriaRequestDTO _Request)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _Response = await _IServicesGeneric.UpdateCategoria(_Request);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }

        [HttpPost, DisableRequestSizeLimit]
        //[Produces("application/json")]
        //[Consumes("application/json", "multipart/form-data")]
        [Route("/DeleteCategoria")]
        public async Task<OperationResult> DeleteCategoria([FromBody] int _IdCategoria)
        {
            OperationResult _Response = new OperationResult();
            try
            {
                _Response = await _IServicesGeneric.DeleteCategoria(_IdCategoria);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.AddException(ex);
            }
            return _Response;
        }


    }
}

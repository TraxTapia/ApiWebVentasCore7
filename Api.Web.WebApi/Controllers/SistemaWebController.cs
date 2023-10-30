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

    }
}

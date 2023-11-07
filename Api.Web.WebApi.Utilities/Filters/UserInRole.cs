//using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using MAC.Framework.Identity.Identity;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Api.Web.WebApi.Utilities.Filters
{
    public class UserInRoleAttribute : ActionFilterAttribute, IActionFilter
    {
        public string Application { get; set; }

        //public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    if (actionContext.Request.Headers.Authorization == null)
        //    {
        //        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        //    }
        //    else if (!string.IsNullOrEmpty(this.Application))
        //    {
        //        if (!ContentAuthorize.IsAccessAuthorize(this.Application, actionContext.ActionDescriptor.ControllerDescriptor.ControllerName, actionContext.ActionDescriptor.ActionName))
        //        {
        //            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        //        }
        //    }
        //    else
        //    {
        //        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        //    }
        //    base.OnActionExecuting(actionContext);
        //}
    }
}

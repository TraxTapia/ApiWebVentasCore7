using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
//using System.Web.Http.Results;

public class UserInRoleByApplicationRequirement : AuthorizationHandler<UserInRoleByApplicationRequirement>, IAuthorizationRequirement
{
    public string Application { get; set; }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserInRoleByApplicationRequirement requirement)
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        if (context.User.IsInRole(requirement.Application))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class AuthorizeByApplicationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    public AuthorizeByApplicationAttribute(string application)
    {
        Application = application;
    }

    public new string Roles
    {
        get => base.Roles;
        set => base.Roles = value;
    }

    public string Application { get; set; }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var authorizeService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
        var requirement = new UserInRoleByApplicationRequirement { Application = Application };

        var authorized = await authorizeService.AuthorizeAsync(context.HttpContext.User, context, requirement);
        if (!authorized.Succeeded)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }
    }
}

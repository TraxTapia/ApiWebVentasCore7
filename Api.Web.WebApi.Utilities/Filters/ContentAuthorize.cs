using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Utilities.Filters
{
    public class ContentAuthorize
    {
        //public static bool IsAccessAuthorize(string Application, string Module, string Action)
        //{
        //    //using (IdentityAppDbContext _IdentityAppDbContext = new IdentityAppDbContext())
        //    //{
        //    //    var _RolesApplication = _IdentityAppDbContext.RoleContentAuthorization.Where(x => x.Application == Application).ToList();
        //    //    if (!(_RolesApplication != null && _RolesApplication.Count > 0))
        //    //        return false;                
        //    //    var _UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_IdentityAppDbContext));                
        //    //    var _Roles = _UserManager.GetRoles(System.Web.HttpContext.Current.User.Identity.GetUserId());                
        //    //    _RolesApplication = _RolesApplication.Where(x => _Roles.Any(y => y.Equals(x.Role))).ToList();
        //    //    return _RolesApplication.Any(x => x.Module == Module && x.Action == Action);
        //    //}                            
        //    using (IdentityContext _Context = new IdentityContext())
        //    {
        //        var _User = _Context.AspNetUsers.Include(x => x.AspNetRoles.Select(y => y.RoleContentAuthorization))
        //            .FirstOrDefault(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name);
        //        if (_User == null)
        //            return false;
        //        return _User.AspNetRoles.Where(x => x.Visible && x.Aplications.Visible && x.Aplications.Name == Application)
        //            .SelectMany(x => x.RoleContentAuthorization)
        //            .Any(x => x.Visible && x.Module == Module && x.Action == Action);
        //    }
        //}
    }
}

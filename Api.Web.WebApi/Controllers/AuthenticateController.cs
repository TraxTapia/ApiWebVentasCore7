using Api.Web.WebApi.DTO.OperationResult;
using Api.Web.WebApi.DTO.Request.Token;
using Api.Web.WebApi.DTO.Response.Token;
using Api.Web.WebApi.Utilities.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Web.WebApi.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly Logger _Logger;
        public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            this._Logger = new Logger(configuration["EnvApp:LogPath"]);
        }

        [HttpPost]
        [Route("/Token")]
        public async Task<IActionResult> Token([FromBody] TokenRequestDTO _Request)
        {
            TokenResponseDTO _Response = new TokenResponseDTO();
            try
            {
                var user = await _userManager.FindByEmailAsync(_Request.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, _Request.Password))
                {
                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        return Unauthorized();
                    }
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    JwtSecurityToken _JwtSecurityToken = SecurityToken(authClaims);
                    DateTime Expiration = _JwtSecurityToken.ValidTo;
                    _Response.Username = _Request.UserName;
                    _Response.AccessToken = new JwtSecurityTokenHandler().WriteToken(_JwtSecurityToken);
                    _Response.ExpiresAt = Expiration.ToString();
                    _Response.ExpiresIn = (int)(Expiration - DateTime.Now).TotalSeconds;
                    _Response.TokenType = "Bearer";
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _Response.Result.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _Response.Result.AddException(ex);
            }
            return Ok(_Response);
        }
        private JwtSecurityToken SecurityToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

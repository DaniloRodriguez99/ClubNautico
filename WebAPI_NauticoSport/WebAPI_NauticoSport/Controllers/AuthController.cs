using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace WebAPI_NauticoSport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private static IConfiguration _configuration;
        private Domain.DomainFacade domainFacade;

        public AuthController(IConfiguration config)
        {
            _configuration = config;
            domainFacade = new Domain.DomainFacade(_configuration);
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] LoginIn input)
        {

            LoginOut response = domainFacade.login(input);
            if (response.Result == OperationResult.success)
            {
                List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserName", response.User.Username),
                new Claim("UserId", response.User.UserId.ToString()),
                new Claim("Genre", ((int)response.User.Genre).ToString()),
                new Claim("Role", ((int)response.User.Role).ToString()),
                };

                foreach (Feature feature in response.Features)
                {

                    claims.Add(new Claim("Features", Json(feature).ToString()));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(15),
                            signingCredentials: signIn
                );


                response.Token = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(response);
            }
            return NotFound("Usuario o contraseña incorrecta");

        }

        [HttpGet("refreshToken")]
        [Authorize]
        public IActionResult refreshUserToken() {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            return Ok();
        }

        private static bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidIssuer = _configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            };
        }
    }
}

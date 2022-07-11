using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            if (response.operationResult == OperationResult.success)
            {
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserName", response.user.Username),
                new Claim("UserId", response.user.UserId.ToString()),
                new Claim("Genre", ((int)response.user.Genre).ToString()),
                new Claim("UserType", ((int)response.user.UserType).ToString()),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddSeconds(20),
                            signingCredentials: signIn
                );


                response.token = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(response);
            }
            return NotFound("Usuario o contraseña incorrecta");

        }
    }
}

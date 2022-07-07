using CrossCuttingConcerns.DTOs;
using Microsoft.AspNetCore.Http;
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
        public IConfiguration _configuration;
        private Domain.DomainFacade domainFacade = new Domain.DomainFacade();

        public AuthController(IConfiguration config) {
            _configuration = config;
        }

        [HttpPost("login")]
        public IActionResult login([FromBody]LoginIn input)
        {

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserName", input.userName),
                new Claim("Password", input.password)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddSeconds(20),
                        signingCredentials: signIn
            );

            LoginOut response = domainFacade.login(input);

            response.token = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI_NauticoSport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private static IConfiguration _configuration;
        private Domain.DomainFacade domainFacade = new Domain.DomainFacade(_configuration);

        public UserController(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpGet("features")]
        public IActionResult getFeaturesByUser() {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            return Ok(identity);
        }
    }
}

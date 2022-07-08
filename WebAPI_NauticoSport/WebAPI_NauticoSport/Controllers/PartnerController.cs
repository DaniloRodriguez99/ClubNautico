using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI_NauticoSport.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PartnerController : Controller
    {
        private static IConfiguration _configuration;
        private Domain.DomainFacade domainFacade = new Domain.DomainFacade(_configuration);

        public PartnerController(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpGet]
        public IActionResult GetPartner()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Ok(
                    new GetPartnerOut()
                    {
                        Username = identity.FindFirst("Username").Value,
                        UserId = int.Parse(identity.FindFirst("UserId").Value),
                        Genre = (GenreEnum)int.Parse(identity.FindFirst("Genre").Value),
                        UserType = (UserTypeEnum)int.Parse(identity.FindFirst("UserType").Value),

                    }
                );
            }
            return NotFound("Socio no encontrado");
        }
    }
}

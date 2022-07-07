using CrossCuttingConcerns.DTOs;
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
        private Domain.DomainFacade domainFacade = new Domain.DomainFacade();

        [HttpGet]
        public GetPartnerOut GetPartner()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return new GetPartnerOut()
                {
                    Email = identity.FindFirst("Password").Value,
                    Username = identity.FindFirst("Username").Value
                };
            }
            return null;
        }
    }
}

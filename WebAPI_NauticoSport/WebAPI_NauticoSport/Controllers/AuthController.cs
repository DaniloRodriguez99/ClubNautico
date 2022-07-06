using CrossCuttingConcerns.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_NauticoSport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private Domain.DomainFacade domainFacade = new Domain.DomainFacade();
        // GET: AuthController
        [HttpPost("login")]
        public LoginOut login(LoginIn input)
        {
            return domainFacade.login(input);
        }
    }
}

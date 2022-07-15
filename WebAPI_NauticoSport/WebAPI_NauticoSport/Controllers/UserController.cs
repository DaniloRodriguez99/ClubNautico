using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
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
            var output = new GetFeaturesByUserOut();
            if (identity != null) {

                return Ok(
                    output = domainFacade.GetFeaturesByUser(
                            new GetFeaturesByUserIn()
                            {
                                User = new User()
                                {
                                    UserId = int.Parse(identity.FindFirst("UserId").Value),
                                    Name = identity.FindFirst("Name").Value,
                                    LastName = identity.FindFirst("Lastname").Value,
                                    Username = identity.FindFirst("Username").Value,
                                    CI = int.Parse(identity.FindFirst("Ci").Value),
                                    Email = identity.FindFirst("Username").Value,
                                    Genre = (GenreEnum)int.Parse(identity.FindFirst("Genre").Value),
                                    Birthday = DateTime.MinValue,
                                    CreationDate = DateTime.MinValue,
                                    UserType = (UserTypeEnum)int.Parse(identity.FindFirst("UserType").Value),
                                }
                            }

                            )
                            
                    
                    );;
            }
            return Ok(output);
        }
    }
}

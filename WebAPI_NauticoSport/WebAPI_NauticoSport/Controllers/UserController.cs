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
        private Domain.DomainFacade domainFacade;

        public UserController(IConfiguration config)
        {
            _configuration = config;
            domainFacade = new Domain.DomainFacade(_configuration);
        }

        [HttpPost("signUp")]
        public IActionResult userSignUp([FromBody] UserSignUpIn input) {

            UserSignUpOut result = domainFacade.userSignUp(input);

            return Ok(result);
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
                                    Lastname = identity.FindFirst("Lastname").Value,
                                    Username = identity.FindFirst("Username").Value,
                                    Ci = int.Parse(identity.FindFirst("Ci").Value),
                                    Email = identity.FindFirst("Username").Value,
                                    Genre = (GenreEnum)int.Parse(identity.FindFirst("Genre").Value),
                                    Birthday = DateTime.MinValue,
                                    CreationDate = DateTime.MinValue,
                                    Role = (RoleEnum)int.Parse(identity.FindFirst("Role").Value),
                                }
                            }

                            )
                            
                    
                    );;
            }
            return Ok(output);
        }

        [HttpGet("users")]
        public IActionResult getUsers([FromQuery] GetUsersIn input)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var output = new GetUsersOut() { Result = OperationResult.failure };
            if (identity != null)
            {
                output = domainFacade.getUsers(input);
                return Ok(output);
            }
            return BadRequest(output);
        }
    }
}

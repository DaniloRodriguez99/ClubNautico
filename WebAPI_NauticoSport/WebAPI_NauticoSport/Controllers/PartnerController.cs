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
        public IActionResult GetPartnerById([FromQuery] GetPartnerByIdIn input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            GetPartnerByIdOut result = new GetPartnerByIdOut() { Result = OperationResult.failure };
            try
            {

                if (identity != null)
                {
                    result = domainFacade.getPartnerById(input);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("list")]
        public IActionResult getPartners([FromQuery] GetPartnersIn input)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var output = new GetPartnersOut() { Result = OperationResult.failure };
            if (identity != null)
            {
                output = domainFacade.getPartners(input);
                return Ok(output);
            }
            return BadRequest(output);
        }
    }
}

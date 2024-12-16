using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMasterAppBackend.Services.Hotels;
using TravelMasterAppBackend.Services.Tours;
using TravelMasterAppBackend.Services.Users;

namespace TravelMasterAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public readonly UserService UserService;
        public readonly HotelService HotelService;
        public HotelController()
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ConnectionString"];
            UserService = new UserService(ConnectionString);
            HotelService = new HotelService(ConnectionString);
        }

        [HttpGet("get/by-id/{id}")]
        public IActionResult ReadAll([FromHeader] string accessToken, [FromRoute] int id)
        {
            if (UserService.HasAdminAccess(accessToken))
            {
                return Unauthorized();
            }

            return Ok(HotelService.ReadById(id));
        }

        [HttpGet("get/all/")]
        public IActionResult ReadAll([FromHeader] string accessToken)
        {
            if (UserService.HasAdminAccess(accessToken))
            {
                return Unauthorized();
            }

            return Ok(HotelService.ReadMany());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMasterAppBackend.Services.Tours;
using TravelMasterAppBackend.Services.Tours.Dtos;
using TravelMasterAppBackend.Services.Users;

namespace TravelMasterAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        public readonly UserService UserService;
        public readonly TourService TourService;
        public TourController()
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ConnectionString"];
            UserService = new UserService(ConnectionString);
            TourService = new TourService(ConnectionString);
        }

        [HttpPost("get/all/")]
        public IActionResult ReadAll([FromHeader] string accessToken, [FromBody] ToursRequest request)
        {
            return Ok(TourService.ReadMany(request));
        }
    }
}

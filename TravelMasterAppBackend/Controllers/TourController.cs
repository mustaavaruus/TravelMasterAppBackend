using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMasterAppBackend.Services.Tours;
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
            UserService = new UserService("Server=DESKTOP-TFC9VKL;Database=enterprise_process_db;Integrated Security=true;Encrypt=False;");
            TourService = new TourService("Server=DESKTOP-TFC9VKL;Database=enterprise_process_db;Integrated Security=true;Encrypt=False;");
        }

        [HttpGet("get/all/")]
        public IActionResult ReadAll([FromHeader] string accessToken)
        {
            return Ok(TourService.ReadMany());
        }
    }
}

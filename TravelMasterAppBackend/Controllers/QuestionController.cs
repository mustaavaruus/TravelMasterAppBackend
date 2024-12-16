using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMasterAppBackend.Services.Questions;
using TravelMasterAppBackend.Services.Users;

namespace TravelMasterAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public readonly UserService UserService;
        public readonly QuestionService QuestionService;
        public QuestionController()
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ConnectionString"];
            UserService = new UserService(ConnectionString);
            QuestionService = new QuestionService(ConnectionString);
        }

        [HttpGet("get/{number}")]
        public IActionResult GetMyUser([FromHeader] string accessToken, [FromRoute] int number)
        {
            if (!UserService.HasUserAccess(accessToken) && !UserService.HasAdminAccess(accessToken))
            {
                return Unauthorized();
            }

            return Ok(QuestionService.ReadByNumber(number));

        }
    }
}

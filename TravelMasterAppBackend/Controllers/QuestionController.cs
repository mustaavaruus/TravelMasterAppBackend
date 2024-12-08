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
            UserService = new UserService("Server=DESKTOP-TFC9VKL;Database=enterprise_process_db;Integrated Security=true;Encrypt=False;");
            QuestionService = new QuestionService("Server=DESKTOP-TFC9VKL;Database=enterprise_process_db;Integrated Security=true;Encrypt=False;");
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

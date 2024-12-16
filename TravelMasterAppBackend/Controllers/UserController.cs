using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMasterAppBackend.Services.Users.Dtos;
using TravelMasterAppBackend.Services.Users.Models;
using TravelMasterAppBackend.Services.Users;
using Microsoft.AspNetCore.Cors;

namespace TravelMasterAppBackend.Controllers
{
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserService UserService;
        public UserController()
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ConnectionString"];
            UserService = new UserService(ConnectionString);
        }

        [HttpPost]
        public void Create([FromBody] User user)
        {
            UserService.Create(user);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            UserService.Create(user);

            return Ok("Success");
        }

        [HttpGet("get-my-account")]
        public IActionResult GetMyUser([FromHeader] string accessToken)
        {
            return Ok(UserService.GetUserByAccessToken(accessToken));
        }

        [HttpGet("get/id/{id}")]
        public IActionResult Read([FromRoute] int id, [FromHeader] string accessToken)
        {
            if (UserService.HasAdminAccess(accessToken))
            {
                return Unauthorized();
            }

            return Ok(UserService.Read(id));
        }

        [HttpGet("get/all/")]
        public IActionResult ReadAll([FromHeader] string accessToken)
        {
            if (UserService.HasAdminAccess(accessToken))
            {
                return Unauthorized();
            }

            return Ok(UserService.ReadMany());
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user, [FromHeader] string accessToken)
        {
            if (UserService.HasAdminAccess(accessToken))
            {
                return Unauthorized();
            }

            UserService.Update(user);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id, [FromHeader] string accessToken)
        {
            if (UserService.HasAdminAccess(accessToken))
            {
                return Unauthorized();
            }

            UserService.Delete(id);

            return Ok();
        }

        [DisableCors]
        [HttpPost("auth/")]
        public IActionResult Auth([FromBody] UserDto user)
        {
            try
            {
                return Ok(UserService.Auth(user));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

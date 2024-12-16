using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMasterAppBackend.Services.Banks.Models;
using TravelMasterAppBackend.Services.Banks;

namespace TravelMasterAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        public readonly BankService BankService;
        public BankController()
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ConnectionString"];
            BankService = new BankService(ConnectionString);
        }

        [HttpPost]
        public void Create([FromBody] Bank provider)
        {
            BankService.Create(provider);
        }

        [HttpGet("get/id/{id}")]
        public IActionResult Read([FromRoute] int id)
        {
            return Ok(BankService.Read(id));
        }

        [HttpGet("get/all/")]
        public IActionResult ReadAll([FromHeader] string accessToken)
        {
            return Ok(BankService.ReadMany(accessToken));
        }

        [HttpPut]
        public void Update([FromBody] Bank provider)
        {
            BankService.Update(provider);
        }

        [HttpDelete("delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            BankService.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using TravelMasterAppBackend.Services.Tickets;
using TravelMasterAppBackend.Services.Tickets.Models;

namespace TravelMasterAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public readonly TicketService TicketService;
        public TicketController()
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ConnectionString"];
            TicketService = new TicketService(ConnectionString);
        }

        [HttpPost]
        public void Create([FromBody] Ticket provider)
        {
            TicketService.Create(provider);
        }

        [HttpGet("get/id/{id}")]
        public IActionResult Read([FromRoute] int id)
        {
            return Ok(TicketService.Read(id));
        }

        [HttpGet("get/all/{cityId}")]
        public IActionResult ReadAll([FromHeader] string accessToken, [FromRoute] int cityId)
        {
            return Ok(TicketService.ReadMany(accessToken, cityId));
        }

        [HttpGet("get/count/{cityId}")]
        public IActionResult GetCount([FromHeader] string accessToken, [FromRoute] int cityId)
        {
            return Ok(TicketService.GetCount(accessToken, cityId));
        }

        [HttpPut]
        public void Update([FromBody] Ticket provider)
        {
            TicketService.Update(provider);
        }

        [HttpDelete("delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            TicketService.Delete(id);
        }
    }
}

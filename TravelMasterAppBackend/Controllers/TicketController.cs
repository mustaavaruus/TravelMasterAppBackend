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
            TicketService = new TicketService("Server=WIN-Q84SKP32UDM;Database=enterprise_process_db;Integrated Security=true;Encrypt=False;");
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

        [HttpGet("get/all/")]
        public IActionResult ReadAll([FromHeader] string accessToken)
        {
            return Ok(TicketService.ReadMany(accessToken));
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

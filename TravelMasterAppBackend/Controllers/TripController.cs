using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMasterAppBackend.Services.Trips;
using TravelMasterAppBackend.Services.Trips.Dtos;
using TravelMasterAppBackend.Services.Trips.Models;

namespace TravelMasterAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        public readonly TripService TripService;
        public TripController()
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ConnectionString"];
            TripService = new TripService(ConnectionString);
        }

        [HttpPost]
        public void Create([FromBody] Trip provider)
        {
            TripService.Create(provider);
        }

        [HttpGet("get/id/{id}")]
        public IActionResult Read([FromRoute] int id)
        {
            return Ok(TripService.Read(id));
        }

        [HttpPost("get/all/")]
        public IActionResult ReadAll([FromHeader] string accessToken, [FromBody] TripRequestDto dto)
        {
            return Ok(TripService.ReadMany(accessToken, dto));
        }

        [HttpPut]
        public void Update([FromBody] Trip provider)
        {
            TripService.Update(provider);
        }

        [HttpDelete("delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            TripService.Delete(id);
        }
    }
}

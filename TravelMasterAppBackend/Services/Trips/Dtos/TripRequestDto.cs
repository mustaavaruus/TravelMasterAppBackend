namespace TravelMasterAppBackend.Services.Trips.Dtos
{
    public class TripRequestDto
    {
        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CityId { get; set; }
    }
}

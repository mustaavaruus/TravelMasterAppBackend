using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Trips.Models
{
    public class Trip
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("ticket_first_id")]
        public int TicketFirstId  { get; set; }

        [DbColumn("ticket_second_id")]
        public int TicketSecondId { get; set; }
    }
}

using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Tickets.Dtos
{
    public class TicketDto
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("begin_dt")]
        public DateTime BeginDt { get; set; }

        [DbColumn("end_dt")]
        public DateTime EndDt { get; set; }

        [DbColumn("price")]
        public int Price { get; set; }

        [DbColumn("city_from")]
        public string CityFrom { get; set; }

        [DbColumn("city_to")]
        public string CityTo { get; set; }

        [DbColumn("luggage_price")]
        public int LuggagePrice { get; set; }

        [DbColumn("transfer_count")]
        public int TransferCount { get; set; }
    }
}

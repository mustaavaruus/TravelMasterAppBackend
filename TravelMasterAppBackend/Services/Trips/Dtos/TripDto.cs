using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Trips.Dtos
{
    public class TripDto
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("price")]
        public int Price { get; set; }

        [DbColumn("id_1")]
        public int Id1 { get; set; }

        [DbColumn("begin_dt_1")]
        public DateTime BeginDt1 { get; set; }

        [DbColumn("end_dt_1")]
        public DateTime EndDt1 { get; set; }

        [DbColumn("price_1")]
        public int Price1 { get; set; }

        [DbColumn("from_id_1")]
        public int FromId1 { get; set; }

        [DbColumn("to_id_1")]
        public int ToId1 { get; set; }

        [DbColumn("luggage_price_1")]
        public int LuggagePrice1 { get; set; }

        [DbColumn("transfer_count_1")]
        public int TransferCount1 { get; set; }

        [DbColumn("duration_1")]
        public int Duration1 { get; set; }

        [DbColumn("id_2")]
        public int Id2 { get; set; }

        [DbColumn("begin_dt_2")]
        public DateTime BeginDt2 { get; set; }

        [DbColumn("end_dt_2")]
        public DateTime EndDt2 { get; set; }

        [DbColumn("price_2")]
        public int Price2 { get; set; }

        [DbColumn("from_id_2")]
        public int FromId2 { get; set; }

        [DbColumn("to_id_2")]
        public int ToId2 { get; set; }

        [DbColumn("luggage_price_2")]
        public int LuggagePrice2 { get; set; }

        [DbColumn("transfer_count_2")]
        public int TransferCount2 { get; set; }

        [DbColumn("duration_2")]
        public int Duration2 { get; set; }

        [DbColumn("city_alias_1")]
        public string CityAlias1 { get; set; }

        [DbColumn("city_alias_2")]
        public string CityAlias2 { get; set; }
    }
}

using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Hotels.Models
{
    public class Hotel
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("name")]
        public string Name { get; set; }

        [DbColumn("country_id")]
        public int CountryId { get; set; }

        [DbColumn("city_id")]
        public int CityId { get; set; }

        [DbColumn("price")]
        public int Price { get; set; }

        [DbColumn("stars")]
        public int Stars { get; set; }

        [DbColumn("image")]
        public string Image { get; set; }

        [DbColumn("description")]
        public string Description { get; set; }
    }
}

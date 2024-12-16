using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Tours.Dtos
{
    public class TourDto
    {

        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("name")]
        public string Name { get; set; }

        [DbColumn("country_id")]
        public int CountryId { get; set; }

        [DbColumn("country_name")]
        public string CountryName { get; set; }

        [DbColumn("city_id")]
        public int CityId { get; set; }

        [DbColumn("city_name")]
        public string CityName { get; set; }

        [DbColumn("price")]
        public int Price { get; set; }

        [DbColumn("stars")]
        public int Stars { get; set; }

        [DbColumn("image")]
        public string Image { get; set; }

    }
}

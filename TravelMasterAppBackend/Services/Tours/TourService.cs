using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Tours.Dtos;
using TravelMasterAppBackend.Services.Tours.Models;

namespace TravelMasterAppBackend.Services.Tours
{
    public class TourService : CommonService
    {
        public TourService(string connectionString) : base(connectionString)
        {

        }

        public List<TourDto> ReadMany()
        {
            var sqlString = $@"
                SELECT 
	                tour.id as id,
	                tour.name as name,
	                tour.country_id as country_id,
	                tour.city_id as city_id,
	                tour.price as price,
	                tour.stars as stars,
	                tour.image as image,
	                country.name as country_name,
	                city.name as city_name
                FROM [travelling_db].[dbo].[tour]
                JOIN [travelling_db].[dbo].[country] ON tour.country_id = country.id
                JOIN [travelling_db].[dbo].[city] ON tour.city_id = city.id
            ";
            return ReadMany<TourDto>(sqlString);
        }
    }
}

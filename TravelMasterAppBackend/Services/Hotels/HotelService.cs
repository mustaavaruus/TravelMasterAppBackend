using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Hotels.Dtos;
using TravelMasterAppBackend.Services.Tours.Dtos;

namespace TravelMasterAppBackend.Services.Hotels
{
    public class HotelService : CommonService
    {
        public HotelService(string connectionString) : base(connectionString)
        {

        }

        public List<HotelDto> ReadMany()
        {
            var sqlString = $@"
                SELECT 
	                hotel.id as id,
	                hotel.name as name,
	                hotel.country_id as country_id,
	                hotel.city_id as city_id,
	                hotel.price as price,
	                hotel.stars as stars,
	                hotel.image as image,
	                hotel.description as description,
	                country.name as country_name,
	                city.name as city_name
                FROM [travelling_db].[dbo].[hotel]
                JOIN [travelling_db].[dbo].[country] ON hotel.country_id = country.id
                JOIN [travelling_db].[dbo].[city] ON hotel.city_id = city.id
            ";
            return ReadMany<HotelDto>(sqlString);
        }

        public HotelDto ReadById(int id)
        {
            var sqlString = $@"
                SELECT 
	                hotel.id as id,
	                hotel.name as name,
	                hotel.country_id as country_id,
	                hotel.city_id as city_id,
	                hotel.price as price,
	                hotel.stars as stars,
	                hotel.image as image,
	                hotel.description as description,
	                country.name as country_name,
	                city.name as city_name
                FROM [travelling_db].[dbo].[hotel]
                JOIN [travelling_db].[dbo].[country] ON hotel.country_id = country.id
                JOIN [travelling_db].[dbo].[city] ON hotel.city_id = city.id
                WHERE hotel.id = {id}
            ";
            return Read<HotelDto>(sqlString);
        }
    }
}

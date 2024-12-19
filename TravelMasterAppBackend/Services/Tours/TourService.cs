using System.Text;
using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Questions.Models;
using TravelMasterAppBackend.Services.Tours.Dtos;
using TravelMasterAppBackend.Services.Tours.Models;

namespace TravelMasterAppBackend.Services.Tours
{
    public class TourService : CommonService
    {
        public TourService(string connectionString) : base(connectionString)
        {

        }

        public List<TourDto> ReadMany(ToursRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if ((request.Answers == null) || (request.Answers.Count == 0))
            {
                throw new ArgumentNullException(nameof(request.Answers));
            }

            var sb = new StringBuilder();
            sb.Append(
                $@"
                SELECT 
                DISTINCT
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
                JOIN [travelling_db].[dbo].[inclusion] as inclusion  ON inclusion.tour_id = tour.id
            ");

            if (request.Answers.Count > 0)
            {
                sb.AppendLine($@"WHERE");

                for (var i = 0; i < request.Answers.Count; i++)
                {
                    sb.AppendLine($@"inclusion.answer_id = {request.Answers[i].AnswerId} and inclusion.is_included = 1 ");

                    if (request.Answers.Count - 1 > i)
                    {
                        sb.AppendLine("or");
                    }
                }
            }
            sb.AppendLine("order by id");

            return ReadMany<TourDto>(sb.ToString());
        }
    }
}

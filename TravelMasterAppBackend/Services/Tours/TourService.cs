using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Tours.Models;

namespace TravelMasterAppBackend.Services.Tours
{
    public class TourService : CommonService
    {
        public TourService(string connectionString) : base(connectionString)
        {

        }

        public List<Tour> ReadMany()
        {
            var sqlString = $"SELECT * FROM [travelling_db].[dbo].[tour]";
            return ReadMany<Tour>(sqlString);
        }
    }
}

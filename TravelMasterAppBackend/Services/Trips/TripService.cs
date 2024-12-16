using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Trips.Dtos;
using TravelMasterAppBackend.Services.Trips.Models;
using TravelMasterAppBackend.Services.Users.Enums;
using TravelMasterAppBackend.Services.Users;

namespace TravelMasterAppBackend.Services.Trips
{
    public class TripService : CommonService
    {
        private readonly UserService userService;
        public TripService(string connectionString) : base(connectionString)
        {
            userService = new UserService(connectionString);
        }

        public void Create(Trip ticket)
        {

        }

        public Trip Read(int id)
        {
            var sqlString = $"";
            return Read<Trip>(sqlString);
        }

        public List<TripDto> ReadMany(string accessToken, TripRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var user = userService.GetUserByAccessToken(accessToken);

            var conditionString = String.Empty;

            if (user.Role == (int)UserRoleEnum.User)
            {
                //conditionString = $@"where dp.id = {user.DepartmentId}";
            }

            var sqlString = $@"
                select 
	                trip.id,
	                (select (first_ticket.price + second_ticket.price)) as price,
	                first_ticket.id as id_1,
                    first_ticket.begin_dt as begin_dt_1,
                    first_ticket.end_dt as end_dt_1,
                    first_ticket.price as price_1,
                    first_ticket.from_id as from_id_1,
                    first_ticket.to_id as to_id_1,
                    first_ticket.luggage_price as luggage_price_1,
                    first_ticket.transfer_count as transfer_count_1,
                    first_ticket.duration as duration_1,
	                second_ticket.id as id_2,
                    second_ticket.begin_dt as begin_dt_2,
                    second_ticket.end_dt as end_dt_2,
                    second_ticket.price as price_2,
                    second_ticket.from_id as from_id_2,
                    second_ticket.to_id as to_id_2,
                    second_ticket.luggage_price as luggage_price_2,
                    second_ticket.transfer_count as transfer_count_2,
                    second_ticket.duration as duration_2,
	                first_city.alias as city_alias_1,
	                second_city.alias as city_alias_2
                from [travelling_db].[dbo].[trip] as trip
                JOIN [travelling_db].[dbo].[ticket] as first_ticket ON trip.ticket_first_id = first_ticket.id 
                JOIN [travelling_db].[dbo].[ticket] as second_ticket ON trip.ticket_second_id = second_ticket.id
                join [travelling_db].[dbo].[city] as first_city ON first_city.id = first_ticket.from_id
                join [travelling_db].[dbo].[city] as second_city ON second_city.id = first_ticket.to_id
                where first_ticket.begin_dt < '{dto.BeginDate.Date}' and second_ticket.end_dt > '{dto.EndDate.Date}'
                ";

            return ReadMany<TripDto>(sqlString);
        }

        public void Update(Trip ticket)
        {
            Validate(ticket);
            var sqlString = $@"";
            Update(sqlString);
        }

        public void Delete(int id)
        {
            var sqlString = $"";
            Delete(sqlString);
        }

        private void Validate(Trip ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Пустой объект!");
            }
        }
    }
}

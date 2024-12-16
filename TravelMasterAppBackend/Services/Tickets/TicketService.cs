using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Tickets.Models;
using TravelMasterAppBackend.Services.Users.Enums;
using TravelMasterAppBackend.Services.Users;
using TravelMasterAppBackend.Services.Tickets.Dtos;

namespace TravelMasterAppBackend.Services.Tickets
{
    public class TicketService : CommonService
    {
        private readonly UserService userService;
        public TicketService(string connectionString) : base(connectionString)
        {
            userService = new UserService(connectionString);
        }

        public void Create(Ticket ticket)
        {

        }

        public Ticket Read(int id)
        {
            var sqlString = $"";
            return Read<Ticket>(sqlString);
        }

        public List<TicketDto> ReadMany(string accessToken, int cityId)
        {
            var user = userService.GetUserByAccessToken(accessToken);

            var conditionString = String.Empty;

            if (user.Role == (int)UserRoleEnum.User)
            {
                //conditionString = $@"where dp.id = {user.DepartmentId}";
            }

            var sqlString = $@"
                select ticket.id,
		            ticket.begin_dt,
		            ticket.end_dt,
		            ticket.price,
		            ticket.from_id,
		            ticket.luggage_price,
		            ticket.transfer_count,
		            (select top 1 name from [travelling_db].[dbo].[city] where id = from_id) as city_from,
		            (select top 1 name from [travelling_db].[dbo].[city] where id = to_id) as city_to
                from [travelling_db].[dbo].[ticket] as ticket
                where to_id = {cityId} and from_id = 7
                ";

            return ReadMany<TicketDto>(sqlString);
        }

        public TicketCountDto GetCount(string accessToken, int cityId)
        {
            var user = userService.GetUserByAccessToken(accessToken);

            var conditionString = String.Empty;

            if (user.Role == (int)UserRoleEnum.User)
            {
                //conditionString = $@"where dp.id = {user.DepartmentId}";
            }

            var sqlString = $@"
                select count(*)
                from [travelling_db].[dbo].[ticket] as ticket
                where to_id = {cityId} and from_id = 7
                ";

            return Read<TicketCountDto>(sqlString);
        }

        public void Update(Ticket ticket)
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

        private void Validate(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Пустой объект!");
            }
        }
    }
}

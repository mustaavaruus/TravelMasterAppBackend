using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Tickets.Models;
using TravelMasterAppBackend.Services.Users.Enums;
using TravelMasterAppBackend.Services.Users;

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

        public List<Ticket> ReadMany(string accessToken)
        {
            var user = userService.GetUserByAccessToken(accessToken);

            var conditionString = String.Empty;

            if (user.Role == (int)UserRoleEnum.User)
            {
                //conditionString = $@"where dp.id = {user.DepartmentId}";
            }

            var sqlString = $@"" + conditionString;



            return ReadMany<Ticket>(sqlString);
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

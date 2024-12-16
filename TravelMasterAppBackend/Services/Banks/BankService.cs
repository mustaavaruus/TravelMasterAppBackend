using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Banks.Dtos;
using TravelMasterAppBackend.Services.Banks.Models;
using TravelMasterAppBackend.Services.Users.Enums;
using TravelMasterAppBackend.Services.Users;

namespace TravelMasterAppBackend.Services.Banks
{
    public class BankService : CommonService
    {
        private readonly UserService userService;
        public BankService(string connectionString) : base(connectionString)
        {
            userService = new UserService(connectionString);
        }

        public void Create(Bank ticket)
        {

        }

        public Bank Read(int id)
        {
            var sqlString = $"";
            return Read<Bank>(sqlString);
        }

        public List<Bank> ReadMany(string accessToken)
        {
            var user = userService.GetUserByAccessToken(accessToken);

            var conditionString = String.Empty;

            if (user.Role == (int)UserRoleEnum.User)
            {
                //conditionString = $@"where dp.id = {user.DepartmentId}";
            }

            var sqlString = $@"
                select *
                from [travelling_db].[dbo].[bank]
                ";

            return ReadMany<Bank>(sqlString);
        }

        public void Update(Bank ticket)
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

        private void Validate(Bank ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Пустой объект!");
            }
        }
    }
}

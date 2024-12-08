using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Users.Dtos;
using TravelMasterAppBackend.Services.Users.Enums;
using TravelMasterAppBackend.Services.Users.Models;

namespace TravelMasterAppBackend.Services.Users
{
    public class UserService : CommonService
    {
        public UserService(string connectionString) : base(connectionString)
        {

        }

        public void Create(User user)
        {
            Validate(user);
            var sqlString = $@"
              insert into [travelling_db].[dbo].[user] (surname, name, patronymic, email, phone, access_token, role, password, telegram, vk, instagram)
              values ('{user.Surname}', '{user.Name}', '{user.Patronymic}', '{user.Email}', '{user.Phone}', '{Guid.NewGuid}', {(int)UserRoleEnum.User}, '{user.Password}', '{user.Telegram}', '{user.Vk}', '{user.Instagram}')
            ";
            Create<User>(sqlString);
        }

        public User Auth(UserDto dto)
        {
            var sqlString = $@"SELECT * FROM [travelling_db].[dbo].[user] WHERE (email = '{dto.Email}' or phone = '{dto.Phone}') and password = '{dto.Password}'";
            var user = Read<User>(sqlString);
            return user;
        }

        public User Read(int id)
        {
            var sqlString = $"select * from [travelling_db].[dbo].[user] where id = {id}";
            return Read<User>(sqlString);
        }

        public List<User> ReadMany()
        {
            var sqlString = $"select * from [travelling_db].[dbo].[user]";
            return ReadMany<User>(sqlString);
        }

        public void Update(User user)
        {
            Validate(user);
            var sqlString = $@"
                update [travelling_db].[dbo].[user]
                set surname = '{user.Surname}', 
                    name = '{user.Name}', 
                    patronymic = '{user.Patronymic}', 
                    department_id = user.DepartmentId
                    email = '{user.Email}', 
                where id = {user.Id}";
            Update(sqlString);
        }

        public void Delete(int id)
        {
            var sqlString = $@"
                delete
                from [travelling_db].[dbo].[user]
                where id = {id}";
            Delete(sqlString);
        }

        public bool HasUserAccess(string accessToken)
        {
            var user = GetUserByAccessToken(accessToken);

            return user != null && user.Role == (int)UserRoleEnum.User;
        }

        public bool HasAdminAccess(string accessToken)
        {
            var user = GetUserByAccessToken(accessToken);

            return user != null && user.Role == (int)UserRoleEnum.Admin;
        }

        public User GetUserByAccessToken(string accessToken)
        {
            var sqlString = $@"select * from [travelling_db].[dbo].[user] 
                where access_token = '{accessToken}'";

            var existedUser = Read<User>(sqlString);

            if ((existedUser == null) || (existedUser.Id == 0))
            {
                throw new Exception("Пользователь не найден.");
            }

            return existedUser;
        }

        private void Validate(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Пустой объект!");
            }

            if (String.IsNullOrEmpty(user.Surname) == true)
            {
                throw new ArgumentNullException("Пустая фамилия.");
            }

            if (String.IsNullOrEmpty(user.Name) == true)
            {
                throw new ArgumentNullException("Пустое имя.");
            }
        }
    }
}

using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Users.Models
{
    public class User
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("surname")]
        public string Surname { get; set; }

        [DbColumn("name")]
        public string Name { get; set; }

        [DbColumn("patronymic")]
        public string Patronymic { get; set; }

        [DbColumn("access_token")]
        public string AccessToken { get; set; }

        [DbColumn("role")]
        public int Role { get; set; }

        [DbColumn("email")]
        public string Email { get; set; }

        [DbColumn("phone")]
        public string Phone { get; set; }

        [DbColumn("password")]
        public string Password { get; set; }

        [DbColumn("telegram")]
        public string Telegram { get; set; }

        [DbColumn("vk")]
        public string Vk { get; set; }

        [DbColumn("instagram")]
        public string Instagram { get; set; }
    }
}

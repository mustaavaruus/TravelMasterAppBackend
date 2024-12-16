using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Banks.Models
{
    public class Bank
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("name")]
        public string Name { get; set; }

        [DbColumn("logo")]
        public string Logo { get; set; }
    }
}

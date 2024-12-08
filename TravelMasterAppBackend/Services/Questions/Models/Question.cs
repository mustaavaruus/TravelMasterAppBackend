using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Questions.Models
{
    public class Question
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("text")]
        public string Text { get; set; }

        [DbColumn("image")]
        public string Image { get; set; }
    }
}

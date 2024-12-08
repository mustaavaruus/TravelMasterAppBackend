using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Questions.Models
{
    public class Answer
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("text")]
        public string Text { get; set; }

        [DbColumn("question_id")]
        public int QuestionId { get; set; }

        [DbColumn("image")]
        public string Image { get; set; }
    }
}

namespace TravelMasterAppBackend.Services.Questions.Dtos
{
    public class QuestionDto
    {
        public string QuestionText { get; set; }
        public List<string> AnswerTexts { get; set; } = new List<string>();
        public List<string> ImageTexts { get; set; } = new List<string>();
    }
}

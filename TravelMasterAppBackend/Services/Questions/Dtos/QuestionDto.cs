using TravelMasterAppBackend.Services.Questions.Models;

namespace TravelMasterAppBackend.Services.Questions.Dtos
{
    public class QuestionDto
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();    }
}

using TravelMasterAppBackend.Services.Common;
using TravelMasterAppBackend.Services.Questions.Dtos;
using TravelMasterAppBackend.Services.Questions.Models;

namespace TravelMasterAppBackend.Services.Questions
{
    public class QuestionService : CommonService
    {
        public QuestionService(string connectionString) : base(connectionString)
        {

        }
        public QuestionDto ReadByNumber(int number)
        {
            var sqlQuestionString = $"select * from [travelling_db].[dbo].[question] where number = {number}";
            var question = Read<Question>(sqlQuestionString);

            var sqlAnswerString = $"select * from [travelling_db].[dbo].[answer] where question_id = {question.Id}";
            var answers = ReadMany<Answer>(sqlAnswerString);

            var result = new QuestionDto();
            result.Question = question;
            result.Answers.AddRange(answers);

            return result;
        }
    }
}

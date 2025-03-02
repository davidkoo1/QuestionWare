using QuestionWare.Quiz.Domain.Common;

namespace QuestionWare.Quiz.Domain.Models
{
    public class Quiz : AuditableEntity
    {
        public required string Name { get; set; }
        public required int TimeForQuiz { get; set; }
        public string Description { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<Result> Results { get; set; }
    }
}

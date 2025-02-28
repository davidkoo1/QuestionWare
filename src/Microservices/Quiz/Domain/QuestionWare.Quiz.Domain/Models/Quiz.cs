using QuestionWare.Quiz.Domain.Common;

namespace QuestionWare.Quiz.Domain.Models
{
    public class Quiz : AuditableEntity
    {
        public string Name { get; set; }
        public int TimeForQuiz { get; set; }
        public string Description { get; set; }
    }
}

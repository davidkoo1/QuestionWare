using QuestionWare.Quiz.Domain.Common;

namespace QuestionWare.Quiz.Domain.Models
{
    public class Question : AuditableEntity
    {
        public int OrderNumber { get; set; }
        public string Message { get; set; }
        public int IdQuiz { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual List<AnswerOption> AnswerOptions { get; set; }
    }
}

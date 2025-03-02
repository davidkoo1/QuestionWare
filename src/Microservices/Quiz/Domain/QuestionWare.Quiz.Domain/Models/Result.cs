using QuestionWare.Quiz.Domain.Common;

namespace QuestionWare.Quiz.Domain.Models
{
    public class Result : Entity<int>
    {
        public string ResultDescription { get; set; }
        public int IdQuiz { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual List<Temp> Temps { get; set; }
    }
}

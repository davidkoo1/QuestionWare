using QuestionWare.Quiz.Domain.Common;

namespace QuestionWare.Quiz.Domain.Models
{
    public class AnswerOption : Entity<int>
    {
        //OrderNumber and Audit
        public string AnswerDescription { get; set; }
        public int IdQuestion { get; set; }
        public virtual Question Question { get; set; }
        public virtual List<Temp> Temps { get; set; }
    }
}

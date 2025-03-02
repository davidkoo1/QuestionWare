namespace QuestionWare.Quiz.Domain.Models
{
    public class Temp
    {
        public int IdAnswer { get; set; }
        public int IdResult { get; set; }
        public virtual AnswerOption AnswerOption { get; set; }
        public virtual Result Result { get; set; }
    }
}

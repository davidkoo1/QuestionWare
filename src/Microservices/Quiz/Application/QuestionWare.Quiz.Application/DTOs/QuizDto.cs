using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionWare.Quiz.Application.DTOs
{
    public record QuizDto(int Id, string Name, int TimeForQuiz, string Description);

    public static class QuizMapper
    {
        public static QuizDto ToDto(this QuestionWare.Quiz.Domain.Models.Quiz quiz) 
            => new QuizDto(quiz.Id, 
                           quiz.Name,
                           quiz.TimeForQuiz,
                           quiz.Description);
        
    }
}

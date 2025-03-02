using Dapper;
using MediatR;
using QuestionWare.Quiz.Application.DTOs;
using System.Data;

namespace QuestionWare.Quiz.Application.Commands.Quiz
{
    public record CreateQuizCommand(QuizDto quiz) : IRequest<int>;

    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, int>
    {
        private readonly IDbConnection _dbConnection;

        public CreateQuizCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            const string sql = "INSERT INTO Quiz (Name, TimeForQuiz, Description)" +
                "VALUES (@Name, @TimeForQuiz, @Description)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var newId = await _dbConnection.QuerySingleAsync<int>(sql, new
            {
                Name = request.quiz.Name,
                TimeForQuiz = request.quiz.TimeForQuiz,
                Description = request.quiz.Description
            });

            return newId;
        }
    }
}

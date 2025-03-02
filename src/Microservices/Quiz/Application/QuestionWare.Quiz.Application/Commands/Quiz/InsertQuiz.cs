using Dapper;
using MediatR;
using System.Data;

namespace QuestionWare.Quiz.Application.Commands.Quiz
{
    public record CreateQuizCommand(string Name, int TimeForQuiz, string Description) : IRequest<bool>;

    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, bool>
    {
        private readonly IDbConnection _dbConnection;

        public CreateQuizCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            const string sql = "INSERT INTO Quiz (Name, TimeForQuiz, Description) VALUES (@Name, @TimeForQuiz, @Description)";

            var rowsAffected = await _dbConnection.ExecuteAsync(sql, new
            {
                Name = request.Name,
                TimeForQuiz = request.TimeForQuiz,
                Description = request.Description
            });

            return rowsAffected > 0;
        }
    }
}

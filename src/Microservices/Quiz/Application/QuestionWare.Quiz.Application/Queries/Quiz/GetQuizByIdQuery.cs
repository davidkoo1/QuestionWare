using Dapper;
using MediatR;
using QuestionWare.Quiz.Application.DTOs;
using System.Data;

namespace QuestionWare.Quiz.Application.Queries.Quiz
{
    public record GetQuizByIdQuery(int id) : IRequest<QuizDto>;

    public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, QuizDto>
    {
        private readonly IDbConnection _dbConnection;

        public GetQuizByIdQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;


        public async Task<QuizDto?> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM Quiz WITH (NOLOCK) WHERE Id = @Id";

            var quiz = await _dbConnection.QuerySingleOrDefaultAsync<QuestionWare.Quiz.Domain.Models.Quiz>(sql,
                new { Id = request.id });

            return quiz?.ToDto();
        }

    }
}

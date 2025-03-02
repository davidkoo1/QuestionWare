using Dapper;
using MediatR;
using QuestionWare.Quiz.Application.DTOs;
using System.Data;

namespace QuestionWare.Quiz.Application.Queries.Quiz
{
    public record GetAllQuizzesQuery : IRequest<IEnumerable<QuizDto>>;

    public class GetAllQuizzesHandler : IRequestHandler<GetAllQuizzesQuery, IEnumerable<QuizDto>>
    {
        private readonly IDbConnection _dbConnection;

        public GetAllQuizzesHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;


        public async Task<IEnumerable<QuizDto>> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM Quiz WITH (NOLOCK) ORDER BY CreatedAt DESC";

            var quizzes = await _dbConnection.QueryAsync<QuestionWare.Quiz.Domain.Models.Quiz>(sql);

            return quizzes.Select(q => q.ToDto());
        }
    }
}

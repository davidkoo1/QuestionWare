using Dapper;
using MediatR;
using System.Data;

namespace QuestionWare.Quiz.Application.Queries.Quiz
{
    public record GetAllQuizzesQuery : IRequest<IEnumerable<QuestionWare.Quiz.Domain.Models.Quiz>>;

    public class GetAllQuizzesHandler : IRequestHandler<GetAllQuizzesQuery, IEnumerable<QuestionWare.Quiz.Domain.Models.Quiz>>
    {
        private readonly IDbConnection _dbConnection;

        public GetAllQuizzesHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;
        

        public async Task<IEnumerable<QuestionWare.Quiz.Domain.Models.Quiz>> Handle(GetAllQuizzesQuery request, 
            CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM Quiz WITH (NOLOCK) ORDER BY CreatedAt DESC";
            return await _dbConnection.QueryAsync<QuestionWare.Quiz.Domain.Models.Quiz>(sql);
        }
    }
}

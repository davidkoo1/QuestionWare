using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestionWare.Quiz.Application.Commands.Quiz;
using QuestionWare.Quiz.Application.Queries.Quiz;

namespace QuestionWare.Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("all")] 
        public async Task<ActionResult<IEnumerable<QuestionWare.Quiz.Domain.Models.Quiz>>> GetAllQuizzes()
        {
            var quizzes = await _mediator.Send(new GetAllQuizzesQuery());
            return Ok(quizzes);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand command)
        {
            bool success = await _mediator.Send(command);

            if (success)
                return Ok(new { Message = "Quiz created successfully!" });

            return BadRequest(new { Error = "Failed to create quiz." });
        }
    }
}

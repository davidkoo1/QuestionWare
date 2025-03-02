using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestionWare.Quiz.Application.Commands.Quiz;
using QuestionWare.Quiz.Application.DTOs;
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


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuizDto>))]
        public async Task<ActionResult<IEnumerable<QuizDto>>> GetAllQuizzes()
        {
            GetAllQuizzesQuery query = new GetAllQuizzesQuery();
            IEnumerable<QuizDto> quizzes = await _mediator.Send(query);
            return Ok(quizzes);
        }
        //Get by Id with fulldatail and for partialView

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizDto>> GetQuizById(int id)
        {
            var quiz = await _mediator.Send(new GetQuizByIdQuery(id));
            return quiz is not null ? Ok(quiz) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<QuizDto>> CreateQuiz([FromBody] QuizDto quizDto)
        {
            var command = new CreateQuizCommand(quizDto);
            int newQuizId = await _mediator.Send(command);

            if (newQuizId <= 0)
                return BadRequest(new { Error = "Failed to create quiz." });

            var newQuiz = new QuizDto(newQuizId, quizDto.Name, quizDto.TimeForQuiz, quizDto.Description);

            return CreatedAtAction(nameof(GetQuizById), new { id = newQuizId }, newQuiz);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quipu_task.Commands;
using Quipu_task.Queries;

namespace Quipu_task.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _mediator.Send(new GetAuthorQuery { AuthorId = id });
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            var authorId = await _mediator.Send(command);
            return Ok(authorId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorCommand command)
        {
            if (id != command.AuthorId)
            {
                return BadRequest("Author ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _mediator.Send(new DeleteAuthorCommand { AuthorId = id });
            return NoContent();
        }

    }
}

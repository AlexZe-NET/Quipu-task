using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quipu_task.Commands;
using Quipu_task.Queries;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
    {
        var bookId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetBook), new { id = bookId }, bookId);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var query = new GetBookByIdQuery { BookId = id };
        var book = await _mediator.Send(query);
        if (book == null)
            return NotFound();
        return Ok(book);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var query = new GetAllBooksQuery();
        var books = await _mediator.Send(query);
        return Ok(books);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
    {
        if (id != command.BookId)
            return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var command = new DeleteBookCommand { BookId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

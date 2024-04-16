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
        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var query = new GetBookByIdQuery { BookId = id };
        var book = await _mediator.Send(query);
        if (book == null)
            return NotFound($"Book with id {id} does not exist.");
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
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand command)
    {
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

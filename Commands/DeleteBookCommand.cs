using MediatR;

namespace Quipu_task.Commands
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int BookId { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _bookRepository.GetByIdAsync(request.BookId);
            if (existingBook == null)
            {
                throw new Exception("Book not found.");
            }

            await _bookRepository.DeleteAsync(existingBook);

            return Unit.Value;
        }
    }
}

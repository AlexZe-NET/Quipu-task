using MediatR;

namespace Quipu_task.Commands
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _bookRepository.GetByIdAsync(request.BookId);
            if (existingBook == null)
            {
                throw new Exception("Book not found.");
            }

            existingBook.Title = request.Title;
            existingBook.SubTitle = request.SubTitle;

            await _bookRepository.UpdateAsync(existingBook);

            return Unit.Value;
        }
    }
}

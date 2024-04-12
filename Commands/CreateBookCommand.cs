namespace Quipu_task.Commands
{
    using MediatR;
    using Quipu_task.Models;

    public class CreateBookCommand : IRequest<int>
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }


    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                AuthorId = request.AuthorId,
                Title = request.Title,
                SubTitle = request.SubTitle
            };

            return await _bookRepository.AddAsync(book);
        }
    }
}

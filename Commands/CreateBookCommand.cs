using MediatR;
using Quipu_task.Models;

namespace Quipu_task.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }


    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;


        public CreateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (existingAuthor != null)
            {
                // Author exists, create the book
                var book = new Book
                {
                    AuthorId = existingAuthor.AuthorId,
                    Title = request.Title,
                    SubTitle = request.SubTitle
                };

                return await _bookRepository.AddAsync(book);
            }
            else
            {
                throw new ArgumentException("Invalid author ID");
            }

        }
    }
}

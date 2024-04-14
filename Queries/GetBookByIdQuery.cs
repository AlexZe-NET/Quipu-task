using MediatR;
using Quipu_task.Models;

namespace Quipu_task.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int BookId { get; set; }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetByIdAsync(request.BookId);
        }
    }
}

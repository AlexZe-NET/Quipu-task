using MediatR;
using Quipu_task.Models;

namespace Quipu_task.Queries
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAllAsync();
        }
    }
}

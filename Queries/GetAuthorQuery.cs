using MediatR;
using Quipu_task.Models;

namespace Quipu_task.Queries
{
    public class GetAuthorQuery : IRequest<Author>
    {
        public int AuthorId { get; set; }
    }

    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetByIdAsync(request.AuthorId);
        }
    }
}

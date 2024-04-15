using MediatR;
using Quipu_task.Models;

namespace Quipu_task.Queries
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
    }

    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAllAsync();
        }
    }
}

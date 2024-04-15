using MediatR;
using Quipu_task.Models;

namespace Quipu_task.Commands
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name
            };
            return await _authorRepository.AddAsync(author);
        }
    }
}

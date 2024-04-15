using MediatR;

namespace Quipu_task.Commands
{
    public class UpdateAuthorCommand : IRequest
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (author == null)
            {
                throw new Exception("Author not found");
            }

            author.Name = request.Name;
            await _authorRepository.UpdateAsync(author);

            return Unit.Value;
        }
    }
}

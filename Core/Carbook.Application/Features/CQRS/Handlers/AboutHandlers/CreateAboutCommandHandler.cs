using Carbook.Application.Features.CQRS.Commands.AboutCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            await repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
            });
        }
    }
}

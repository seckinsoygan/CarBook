using Carbook.Application.Features.CQRS.Commands.AboutCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {

            var value = await repository.GetByIdAsync(command.AboutId);
            value.Description = command.Description;
            value.Title = command.Title;
            value.ImageUrl = command.ImageUrl;

            await repository.UpdateAsync(value);
        }
    }
}

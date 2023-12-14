using Carbook.Application.Features.CQRS.Commands.AboutCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var value = await repository.GetByIdAsync(command.AboutId);
            await repository.DeleteAsync(value);
        }
    }
}

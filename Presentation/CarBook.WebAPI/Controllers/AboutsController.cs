using Carbook.Application.Features.CQRS.Commands.AboutCommands;
using Carbook.Application.Features.CQRS.Handlers.AboutHandlers;
using Carbook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler createAboutCommandHandler;
        private readonly GetAboutQueryHandler getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler updateAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
        private readonly RemoveAboutCommandHandler removeAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            this.createAboutCommandHandler = createAboutCommandHandler;
            this.getAboutQueryHandler = getAboutQueryHandler;
            this.updateAboutCommandHandler = updateAboutCommandHandler;
            this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            this.removeAboutCommandHandler = removeAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await createAboutCommandHandler.Handle(command);
            return Ok("Ekleme Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await updateAboutCommandHandler.Handle(command);
            return Ok("Güncelleme Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Silme Başarılı");
        }
    }
}

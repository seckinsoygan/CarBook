using Carbook.Application.Features.CQRS.Results.AboutResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            values.Select(x => new GetAboutByIdQueryResult
            {
                AboutId = x.AboutId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
            }).ToList();
        }
    }
}

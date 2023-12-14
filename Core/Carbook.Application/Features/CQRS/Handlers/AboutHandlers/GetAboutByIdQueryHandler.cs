using Carbook.Application.Features.CQRS.Queries.AboutQueries;
using Carbook.Application.Features.CQRS.Results.AboutResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                Title = values.Title,
            };
        }
    }
}

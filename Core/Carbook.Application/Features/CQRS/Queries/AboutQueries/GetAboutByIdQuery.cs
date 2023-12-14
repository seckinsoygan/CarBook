namespace Carbook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public int Id { get; set; }
        public GetAboutByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}

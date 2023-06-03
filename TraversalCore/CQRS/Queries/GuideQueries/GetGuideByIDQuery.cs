using MediatR;
using TraversalCore.CQRS.Results.GuideResults;

namespace TraversalCore.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}

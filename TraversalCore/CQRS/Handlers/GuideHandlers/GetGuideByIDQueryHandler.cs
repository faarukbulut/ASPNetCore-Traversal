﻿using DataAccessLayer.Concrete;
using MediatR;
using TraversalCore.CQRS.Queries.GuideQueries;
using TraversalCore.CQRS.Results.GuideResults;

namespace TraversalCore.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.id);
            return new GetGuideByIDQueryResult
            {
                GuideID = values.GuideID,
                Name = values.Name,
                Description = values.Description
            };
        }
    }
}

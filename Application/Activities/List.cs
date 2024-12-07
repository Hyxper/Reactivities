using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    //this will be a query handler, query handlers are handlers that are used to query data from the database, not to update or delete data
    public class List
    {
        //this nested class will be used to define the query that will be used to get the list of activities
        public class Query : IRequest<List<Activity>> { }

        //this nested class will be used to define the handler that will be used to handle the query
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {             
                return await _context.Activities.ToListAsync();
            }
        }
    }
}

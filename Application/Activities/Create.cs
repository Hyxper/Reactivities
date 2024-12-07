
using MediatR;
using Persistence;
using Domain;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity? Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            //Task<Unit> is a way to return a void task
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Activity != null)
                {
                    _context.Activities.Add(request.Activity);
                    await _context.SaveChangesAsync();            
                }
                else
                {
                    throw new NullReferenceException("Activity cannot be null");
                }
            }
        }
    }  
}

using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lectors.Commands.UpdateLector
{
    public class UpdateLectorCommandHandler : IRequestHandler<UpdateLectorCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public UpdateLectorCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(UpdateLectorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

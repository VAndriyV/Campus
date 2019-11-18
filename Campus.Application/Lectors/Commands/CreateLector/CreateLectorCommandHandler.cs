using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lectors.Commands.CreateLector
{
    public class CreateLectorCommandHandler : IRequestHandler<CreateLectorCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public CreateLectorCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateLectorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

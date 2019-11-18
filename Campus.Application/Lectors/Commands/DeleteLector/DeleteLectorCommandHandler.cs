using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lectors.Commands.DeleteLector
{
    public class DeleteLectorCommandHandler : IRequestHandler<DeleteLectorCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public DeleteLectorCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(DeleteLectorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

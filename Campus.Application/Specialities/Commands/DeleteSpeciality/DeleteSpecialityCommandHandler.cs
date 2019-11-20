using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Specialities.Commands.DeleteSpeciality
{
    public class DeleteSpecialityCommandHandler : IRequestHandler<DeleteSpecialityCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public DeleteSpecialityCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSpecialityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

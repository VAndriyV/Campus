using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Specialities.Commands.UpdateSpeciality
{
    public class UpdateSpecialityCommandHandler : IRequestHandler<UpdateSpecialityCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public UpdateSpecialityCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSpecialityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

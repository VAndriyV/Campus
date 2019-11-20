using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Specialities.Commands.CreateSpeciality
{
    public class CreateSpecialityCommandHandler : IRequestHandler<CreateSpecialityCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public CreateSpecialityCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

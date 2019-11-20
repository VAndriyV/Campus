using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Attendances.Commands.CreateAttendance
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, Unit>
    {
        private readonly CampusDbContext _context;
        
        public CreateAttendanceCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

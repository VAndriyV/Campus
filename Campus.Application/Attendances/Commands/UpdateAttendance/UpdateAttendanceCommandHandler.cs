using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Attendances.Commands.UpdateAttendance
{
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public UpdateAttendanceCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

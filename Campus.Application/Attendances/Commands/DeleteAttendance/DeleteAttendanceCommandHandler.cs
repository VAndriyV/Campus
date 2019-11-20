using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Attendances.Commands.DeleteAttendance
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public DeleteAttendanceCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

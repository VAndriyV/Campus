using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Attendances.Commands.DeleteAttendance
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public DeleteAttendanceCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var attendance = _context.Attendances.FindAsync(request.Id);
            
            if(attendance == null)
            {
                throw new NotFoundException(nameof(Attendance), request.Id);
            }

            _context.Remove(attendance);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Attendances.Commands.CreateAttendance
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, Unit>
    {
        private readonly CampusDbContext _context;
        
        public CreateAttendanceCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(x => x.LectorSubjectId == request.LectorSubjectId && x.GroupId == request.GroupId);

            if (lesson==null)
            {
                throw new NotFoundException(nameof(Lesson));
            }

            var attendance = new Attendance
            {
                DayOfWeekId = request.DayOfWeekId,
                StudentsCount = request.StudentsCount,
                Date = request.Date,
                LessonId = lesson.Id,
                WeatherTypeId = request.WeatherTypeId
            };

            _context.Attendances.Add(attendance);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

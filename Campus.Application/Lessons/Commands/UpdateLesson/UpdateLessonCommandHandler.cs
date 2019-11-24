using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public UpdateLessonCommandHandler(CampusDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FindAsync(request.Id);

            if (lesson == null)
            {
                throw new NotFoundException(nameof(Lesson), request.Id);
            }

            lesson.LectorSubjectId = request.LectorSubjectId;
            lesson.GroupId = request.GroupId;

            _context.Lessons.Update(lesson);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

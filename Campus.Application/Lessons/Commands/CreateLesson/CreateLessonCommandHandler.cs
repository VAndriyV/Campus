using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Domain.Entities;

namespace Campus.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public CreateLessonCommandHandler(CampusDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = new Lesson
            {
                LectorSubjectId = request.LectorSubjectId,
                GroupId = request.GroupId
            };

            _context.Lessons.Add(lesson);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

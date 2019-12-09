using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;

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
            var lectorSubject = await _context.LectorSubjects.Where(x => x.SubjectId == request.SubjectId
                                                                     && x.LessonTypeId == request.LessonTypeId
                                                                     && x.LectorId == request.LectorId)
                                                                    .FirstOrDefaultAsync();

            if(lectorSubject == null)
            {
                throw new NotFoundException(nameof(LectorSubject));
            }

            var lesson = new Lesson
            {
                LectorSubjectId = lectorSubject.Id,
                GroupId = request.GroupId
            };

            _context.Lessons.Add(lesson);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

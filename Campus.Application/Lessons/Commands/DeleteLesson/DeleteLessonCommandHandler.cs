using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public DeleteLessonCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FindAsync(request.Id);

            if(lesson == null)
            {
                throw new NotFoundException(nameof(Lesson), request.Id);
            }

            _context.Lessons.Remove(lesson);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

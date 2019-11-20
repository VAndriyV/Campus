using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public DeleteLessonCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

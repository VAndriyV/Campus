using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public CreateLessonCommandHandler(CampusDbContext context)
        {
            _context = context;
        }
        public Task<Unit> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

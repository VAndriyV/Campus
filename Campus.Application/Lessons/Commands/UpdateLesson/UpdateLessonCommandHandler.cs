using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public UpdateLessonCommandHandler(CampusDbContext context)
        {
            _context = context;
        }
        public Task<Unit> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

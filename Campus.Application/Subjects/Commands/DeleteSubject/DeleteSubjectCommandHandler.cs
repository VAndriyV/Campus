using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public DeleteSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _context.Subjects.FindAsync(request.Id);
            
            if(subject == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }

            var usedInLectorSubject = await _context.LectorSubjects.AnyAsync(x => x.SubjectId == subject.Id);
            if (usedInLectorSubject)
            {
                throw new DeleteFailureException(nameof(Subject), request.Id, "This subjects is assigned to lectors");
            }

            _context.Subjects.Remove(subject);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

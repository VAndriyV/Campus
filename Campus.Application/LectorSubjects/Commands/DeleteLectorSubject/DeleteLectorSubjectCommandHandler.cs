using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.LectorSubjects.Commands.DeleteLectorSubject
{
    public class DeleteLectorSubjectCommandHandler : IRequestHandler<DeleteLectorSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public DeleteLectorSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLectorSubjectCommand request, CancellationToken cancellationToken)
        {
            var lectorSubject = await _context.LectorSubjects.FindAsync(request.Id);

            if(lectorSubject == null)
            {
                throw new NotFoundException(nameof(LectorSubject), request.Id);
            }

            _context.LectorSubjects.Remove(lectorSubject);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

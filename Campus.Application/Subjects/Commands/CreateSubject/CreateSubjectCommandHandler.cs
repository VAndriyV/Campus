using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Domain.Entities;

namespace Campus.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public CreateSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = new Subject
            {
                Name = request.Name
            };

            _context.Subjects.Add(subject);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

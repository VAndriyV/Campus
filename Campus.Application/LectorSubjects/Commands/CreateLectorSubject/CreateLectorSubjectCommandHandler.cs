using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.LectorSubjects.Commands.CreateLectorSubject
{
    public class CreateLectorSubjectCommandHandler : IRequestHandler<CreateLectorSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public CreateLectorSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(CreateLectorSubjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

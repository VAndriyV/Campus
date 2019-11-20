using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

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
            throw new NotImplementedException();
        }
    }
}

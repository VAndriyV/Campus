using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.LectorSubjects.Commands.UpdateLectorSubject
{
    public class UpdateLectorSubjectCommandHandler : IRequestHandler<UpdateLectorSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public UpdateLectorSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(UpdateLectorSubjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

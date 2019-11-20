using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.LectorSubjects.Commands.DeleteLectorSubject
{
    public class DeleteLectorSubjectCommandHandler : IRequestHandler<DeleteLectorSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;
        public DeleteLectorSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(DeleteLectorSubjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

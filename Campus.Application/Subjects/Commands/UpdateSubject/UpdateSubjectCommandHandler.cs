using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public UpdateSubjectCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Specialities.Commands.DeleteSpeciality
{
    public class DeleteSpecialityCommandHandler : IRequestHandler<DeleteSpecialityCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public DeleteSpecialityCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSpecialityCommand request, CancellationToken cancellationToken)
        {
            var speciality = await _context.Specialities.FindAsync(request.Id);
            
            if(speciality == null)
            {
                throw new NotFoundException(nameof(Speciality), request.Id);
            }

            var groupsWithSpecialityExist = await _context.Groups.AnyAsync(x => x.SpecialityId == request.Id);

            if (groupsWithSpecialityExist)
            {
                throw new DeleteFailureException(nameof(Speciality), request.Id, "There are group(s) on this speciality");
            }

            _context.Specialities.Remove(speciality);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

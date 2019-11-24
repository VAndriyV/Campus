using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Lectors.Commands.UpdateLector
{
    public class UpdateLectorCommandHandler : IRequestHandler<UpdateLectorCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public UpdateLectorCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLectorCommand request, CancellationToken cancellationToken)
        {
            var lector = await _context.Lectors.FindAsync(request.Id);

            if (lector == null)
            {
                throw new NotFoundException(nameof(Lector), request.Id);
            }

            lector.FirstName = request.FirstName;
            lector.LastName = request.LastName;
            lector.Patronymic = request.Patronymic;
            lector.PhoneNumber = request.PhoneNumber;
            lector.Email = request.Email;
            lector.AcademicDegreeId = request.AcademicDegreeId;
            lector.AcademicRankId = request.AcademicRankId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

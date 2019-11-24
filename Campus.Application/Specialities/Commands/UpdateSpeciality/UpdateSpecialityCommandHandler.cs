using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Specialities.Commands.UpdateSpeciality
{
    public class UpdateSpecialityCommandHandler : IRequestHandler<UpdateSpecialityCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public UpdateSpecialityCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSpecialityCommand request, CancellationToken cancellationToken)
        {
            var speciality = await _context.Specialities.FindAsync(request.Id);

            if(speciality == null)
            {
                throw new NotFoundException(nameof(Speciality), request.Id);
            }

            var isSpecialityCodeExist = await _context.Specialities.AnyAsync(x => x.Code == request.Code && x.Id!=speciality.Id);

            if (isSpecialityCodeExist)
            {
                throw new DuplicateException(nameof(Speciality), "Code", request.Code);
            }

            speciality.Name = request.Name;
            speciality.Code = request.Code;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

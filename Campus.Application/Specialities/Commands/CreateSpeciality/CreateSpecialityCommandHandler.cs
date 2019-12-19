using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;

namespace Campus.Application.Specialities.Commands.CreateSpeciality
{
    public class CreateSpecialityCommandHandler : IRequestHandler<CreateSpecialityCommand, int>
    {
        private readonly CampusDbContext _context;

        public CreateSpecialityCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
        {
            var isSpecialityCodeExist = await _context.Specialities.AnyAsync(x => x.Code == request.Code);

            if (isSpecialityCodeExist)
            {
                throw new DuplicateException(nameof(Speciality), "Code", request.Code);
            }

            var speciality = new Speciality
            {
                Name = request.Name,
                Code = request.Code
            };

            _context.Specialities.Add(speciality);

            await _context.SaveChangesAsync(cancellationToken);

            return speciality.Id;
        }
    }
}

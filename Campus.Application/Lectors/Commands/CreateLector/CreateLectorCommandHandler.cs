using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Domain.Entities;

namespace Campus.Application.Lectors.Commands.CreateLector
{
    public class CreateLectorCommandHandler : IRequestHandler<CreateLectorCommand, int>
    {
        private readonly CampusDbContext _context;

        public CreateLectorCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLectorCommand request, CancellationToken cancellationToken)
        {
            var lector = new Lector
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                AcademicDegreeId = request.AcademicDegreeId,
                AcademicRankId = request.AcademicRankId
            };

            _context.Lectors.Add(lector);

            await _context.SaveChangesAsync(cancellationToken);

            return lector.Id;
        }
    }
}

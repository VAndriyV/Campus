using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Exceptions;

namespace Campus.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly CampusDbContext _context;

        public CreateGroupCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var isGroupNameExist = await _context.Groups.AnyAsync(x => x.Name == request.Name);
            if (isGroupNameExist)
            {
                throw new DuplicateException(nameof(Group), "Name", request.Name);
            }

            var group = new Group
            {               
                Name = request.Name,
                SpecialityId = request.SpecialityId,
                EducationalDegreeId = request.EducationalDegreeId,
                StudentsCount = request.StudentsCount,
                Year = request.Year
            };

            _context.Groups.Add(group);

            await _context.SaveChangesAsync(cancellationToken);

            return group.Id;
        }
    }
}

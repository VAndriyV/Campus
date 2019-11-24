using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Campus.Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, int>
    {
        private readonly CampusDbContext _context;

        public UpdateGroupCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups.FindAsync(request.Id);
            if(group == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            var isGroupNameExist = await _context.Groups.AnyAsync(x => x.Name == request.Name && x.Id!=group.Id);
            if (isGroupNameExist)
            {
                throw new DuplicateException(nameof(Group), "Name", request.Name);
            }

            group.Name = request.Name;
            group.SpecialityId = request.SpecialityId;
            group.StudentsCount = request.StudentsCount;
            group.Year = request.Year;
            group.EducationalDegreeId = request.EducationalDegreeId;

            _context.Groups.Update(group);

            await _context.SaveChangesAsync(cancellationToken);

            return group.Id;
        }
    }
}

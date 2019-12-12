using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Exceptions;
using Campus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Campus.Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
    {
        private readonly CampusDbContext _context;

        public DeleteGroupCommandHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups.FindAsync(request.Id);

            if(group == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            var isUsedInLessons = await _context.Lessons.AnyAsync(x => x.GroupId == group.Id);
            if (isUsedInLessons)
            {
                throw new DeleteFailureException(nameof(Group), request.Id, "There are lesson(s) with this group");
            }

            _context.Groups.Remove(group);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

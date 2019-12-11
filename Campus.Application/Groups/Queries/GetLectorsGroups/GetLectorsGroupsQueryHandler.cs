using Campus.Application.Groups.Queries.DataTransferObjects;
using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Groups.Queries.GetLectorsGroups
{
    public class GetLectorsGroupsQueryHandler : IRequestHandler<GetLectorsGroupsQuery, LectorsGroupsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetLectorsGroupsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorsGroupsListViewModel> Handle(GetLectorsGroupsQuery request, CancellationToken cancellationToken)
        {
            var model = new LectorsGroupsListViewModel();

            model.Groups = await _context.Lessons
                .Where(x => x.LectorSubject.LectorId == request.LectorId)
                .Include(x => x.LectorSubject)
                .Include(x => x.Group)
                .GroupBy(x => new { x.Group.Id, x.Group.Name })
                .Select(x=> new GroupDto {Id = x.Key.Id ,Name = x.Key.Name})
                .ToListAsync();

            return model;
        }
    }
}

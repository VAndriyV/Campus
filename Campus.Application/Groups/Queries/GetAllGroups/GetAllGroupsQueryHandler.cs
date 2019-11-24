using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Campus.Application.Groups.Queries.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace Campus.Application.Groups.Queries.GetAllGroups
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, GroupsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllGroupsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<GroupsListViewModel> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            var model = new GroupsListViewModel();

            model.Groups = await _context.Groups.Include(x=>x.Speciality).Include(x=>x.EducationalDegree).
                                          Select(GroupDto.Projection).ToListAsync();

            return model;
        }
    }
}

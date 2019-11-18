using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Groups.Queries.GetAllGroups
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, GroupsListViewModel>
    {
        private readonly CampusDbContext _campus;

        public GetAllGroupsQueryHandler(CampusDbContext campus)
        {
            _campus = campus;
        }

        public Task<GroupsListViewModel> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

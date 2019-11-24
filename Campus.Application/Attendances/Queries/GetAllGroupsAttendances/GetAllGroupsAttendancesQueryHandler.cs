using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Attendances.Queries.GetAllGroupsAttendances
{
    public class GetAllGroupsAttendancesQueryHandler : IRequestHandler<GetAllGroupsAttendancesQuery, GroupsAttendancesListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllGroupsAttendancesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<GroupsAttendancesListViewModel> Handle(GetAllGroupsAttendancesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

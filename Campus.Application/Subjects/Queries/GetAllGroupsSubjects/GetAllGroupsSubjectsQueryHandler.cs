using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Subjects.Queries.GetAllGroupsSubjects
{
    public class GetAllGroupsSubjectsQueryHandler : IRequestHandler<GetAllGroupsSubjectsQuery, GroupsSubjectsListViewModel>
    {
        private readonly CampusDbContext _campus;

        public GetAllGroupsSubjectsQueryHandler(CampusDbContext campus)
        {
            _campus = campus;
        }

        public Task<GroupsSubjectsListViewModel> Handle(GetAllGroupsSubjectsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

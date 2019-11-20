using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lessons.Queries.GetAllGroupsLessons
{
    public class GetAllGroupsLessonsQueryHandler : IRequestHandler<GetAllGroupsLessonsQuery, GroupsLessonsListViewModel>
    {
        private readonly CampusDbContext _context;       

        public GetAllGroupsLessonsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<GroupsLessonsListViewModel> Handle(GetAllGroupsLessonsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

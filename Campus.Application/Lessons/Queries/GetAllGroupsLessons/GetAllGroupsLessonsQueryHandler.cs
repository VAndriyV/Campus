using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Campus.Application.Lessons.Queries.DataTransferObjects;

namespace Campus.Application.Lessons.Queries.GetAllGroupsLessons
{
    public class GetAllGroupsLessonsQueryHandler : IRequestHandler<GetAllGroupsLessonsQuery, GroupsLessonsListViewModel>
    {
        private readonly CampusDbContext _context;       

        public GetAllGroupsLessonsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<GroupsLessonsListViewModel> Handle(GetAllGroupsLessonsQuery request, CancellationToken cancellationToken)
        {
            var model = new GroupsLessonsListViewModel();

            model.Lessons = await _context.Lessons
                .Where(x => x.GroupId == request.GroupId)
                .Include(x => x.LectorSubject)
                .ThenInclude(x => x.Lector)
                .Include(x => x.LectorSubject)
                .ThenInclude(x => x.Subject)
                .Include(x => x.LectorSubject)
                .ThenInclude(x => x.LessonType)
                .Select(LessonDto.Projection)
                .ToListAsync();

            return model;
        }
    }
}

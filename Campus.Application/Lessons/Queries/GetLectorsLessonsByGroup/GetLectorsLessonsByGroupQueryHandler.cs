using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Lessons.Queries.GetLectorsLessonsByGroup
{
    public class GetLectorsLessonsByGroupQueryHandler : IRequestHandler<GetLectorsLessonsByGroupQuery, LectorsLessonByGroupListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetLectorsLessonsByGroupQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorsLessonByGroupListViewModel> Handle(GetLectorsLessonsByGroupQuery request, CancellationToken cancellationToken)
        {
            var model = new LectorsLessonByGroupListViewModel();

            model.Lessons = await _context.Lessons
                .Where(x => x.GroupId == request.GroupId && x.LectorSubject.LectorId == request.LectorId)
                .Include(x => x.LectorSubject)
                .ThenInclude(x => x.Subject)
                .Include(x => x.LectorSubject)
                .ThenInclude(x => x.LessonType)
                .Select(LectorsLessonByGroupModel.Projection)
                .ToListAsync();

            return model;
        }
    }
}

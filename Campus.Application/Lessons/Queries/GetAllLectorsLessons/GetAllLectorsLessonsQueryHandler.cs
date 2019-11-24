using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Campus.Application.Lessons.Queries.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace Campus.Application.Lessons.Queries.GetAllLectorsLessons
{
    public class GetAllLectorsLessonsQueryHandler : IRequestHandler<GetAllLectorsLessonsQuery, LectorsLessonsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllLectorsLessonsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorsLessonsListViewModel> Handle(GetAllLectorsLessonsQuery request, CancellationToken cancellationToken)
        {
            var model = new LectorsLessonsListViewModel();

            model.Lessons = await _context.Lessons
                .Where(x => x.LectorSubject.LectorId == request.LectorId)
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

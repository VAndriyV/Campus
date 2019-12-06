using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Campus.Application.LectorSubjects.Queries.DataTransferObjects;

namespace Campus.Application.LectorSubjects.Queries.GetAllLectorsSubjects
{
    public class GetAllLectorsSubjectsQueryHandler : IRequestHandler<GetAllLectorsSubjectsQuery, LectorsSubjectsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllLectorsSubjectsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorsSubjectsListViewModel> Handle(GetAllLectorsSubjectsQuery request, CancellationToken cancellationToken)
        {
            var model = new LectorsSubjectsListViewModel();

            model.LectorsSubjects = await _context.LectorSubjects
                .Where(x => x.LectorId == request.LectorId)
                .Include(x => x.Subject)
                .Include(x => x.LessonType)
                .Select(LectorSubjectDto.Projection)
                .ToListAsync();

            return model;
        }
    }
}

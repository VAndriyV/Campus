using Campus.Application.LectorSubjects.Queries.DataTransferObjects;
using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.LectorSubjects.Queries.GetLectorsSubjectsByLessonType
{
    public class GetLectorsSubjectsByLessonTypeQueryHandler : IRequestHandler<GetLectorsSubjectsByLessonTypeQuery, LectorsSubjectsByLessonTypeListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetLectorsSubjectsByLessonTypeQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<LectorsSubjectsByLessonTypeListViewModel> Handle(GetLectorsSubjectsByLessonTypeQuery request, CancellationToken cancellationToken)
        {
            var model = new LectorsSubjectsByLessonTypeListViewModel();

            model.LectorsSubjects = await _context.LectorSubjects
                .Where(x => x.LectorId == request.LectorId && x.LessonTypeId == request.LessonTypeId)
                .Include(x => x.Subject)                
                .Select(x => new SubjectInfo { Id = x.SubjectId, Name = x.Subject.Name })
                .ToListAsync();

            return model;
        }
    }
}

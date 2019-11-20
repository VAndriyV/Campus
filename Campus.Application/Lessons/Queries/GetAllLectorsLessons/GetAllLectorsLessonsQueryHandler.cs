using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lessons.Queries.GetAllLectorsLessons
{
    public class GetAllLectorsLessonsQueryHandler : IRequestHandler<GetAllLectorsLessonsQuery, LectorsLessonsListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllLectorsLessonsQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<LectorsLessonsListViewModel> Handle(GetAllLectorsLessonsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

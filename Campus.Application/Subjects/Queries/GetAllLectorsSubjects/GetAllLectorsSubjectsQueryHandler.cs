using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Subjects.Queries.GetAllLectorsSubjects
{
    public class GetAllLectorsSubjectsQueryHandler : IRequestHandler<GetAllLectorsSubjectsQuery, LectorsSubjectsListViewModel>
    {
        private readonly CampusDbContext _campus;

        public GetAllLectorsSubjectsQueryHandler(CampusDbContext campus)
        {
            _campus = campus;
        }

        public Task<LectorsSubjectsListViewModel> Handle(GetAllLectorsSubjectsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

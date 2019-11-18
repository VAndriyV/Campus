using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Subjects.Queries.GetAllSubjects
{
    public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, SubjectsListViewModel>
    {
        private readonly CampusDbContext _campus;

        public GetAllSubjectsQueryHandler(CampusDbContext campus)
        {
            _campus = campus;
        }

        public Task<SubjectsListViewModel> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

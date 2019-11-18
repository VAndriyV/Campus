using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Lectors.Queries.GetAllLectors
{
    public class GetAllLectorsQueryHandler : IRequestHandler<GetAllLectorsQuery, LectorsListViewModel>
    {
        private readonly CampusDbContext _campus;

        public GetAllLectorsQueryHandler(CampusDbContext campus)
        {
            _campus = campus;
        }

        public Task<LectorsListViewModel> Handle(GetAllLectorsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

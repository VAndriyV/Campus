using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;

namespace Campus.Application.Attendances.Queries.GetAllLectorsAttendances
{
    public class GetAllLectorsAttendancesQueryHandler : IRequestHandler<GetAllLectorsAttendancesQuery, LectorsAttendancesListViewModel>
    {
        private readonly CampusDbContext _context;

        public GetAllLectorsAttendancesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public Task<LectorsAttendancesListViewModel> Handle(GetAllLectorsAttendancesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

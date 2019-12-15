using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Attendances.Queries.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Campus.Application.Attendances.Queries.GetAllLectorsAttendances
{
    public class GetAllLectorsAttendancesQueryHandler : IRequestHandler<GetAllLectorsAttendancesQuery, ChartData>
    {
        private readonly CampusDbContext _context;

        public GetAllLectorsAttendancesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<ChartData> Handle(GetAllLectorsAttendancesQuery request, CancellationToken cancellationToken)
        {
            var chartData = new ChartData();

            chartData.Data = await _context.Attendances
                .Include(x => x.Lesson)
                .ThenInclude(x => x.Group)
                .Include(x=>x.Lesson)
                .ThenInclude(x=>x.LectorSubject)
                .Where(x => x.Lesson.LectorSubject.LectorId == request.LectorId
                        && x.Date >= request.StartDate && x.Date <= request.EndDate)
                .Select(x => new ChartDataItem
                {
                    Date = x.Date,
                    AttendancePercentage = (x.StudentsCount / x.Lesson.Group.StudentsCount) * 100
                }).ToListAsync();

            return chartData;
        }
    }
}

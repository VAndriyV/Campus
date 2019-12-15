using Campus.Application.Attendances.Queries.DataTransferObjects;
using Campus.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Attendances.Queries.GetAllAttendances
{
    public class GetAllAttendancesQueryHandler : IRequestHandler<GetAllAttendancesQuery, ChartData>
    {
        private readonly CampusDbContext _context;

        public GetAllAttendancesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<ChartData> Handle(GetAllAttendancesQuery request, CancellationToken cancellationToken)
        {
            var chartData = new ChartData();

            chartData.Data = await _context.Attendances
                .Include(x=>x.Lesson)
                .ThenInclude(x=>x.Group)
                .Where(x => x.Date >= request.StartDate && x.Date <= request.EndDate)
                .Select(x => new ChartDataItem
                {
                    Date = x.Date,
                    AttendancePercentage = ((double)x.StudentsCount / x.Lesson.Group.StudentsCount)*100
                }).ToListAsync();

            return chartData;
        }
    }
}

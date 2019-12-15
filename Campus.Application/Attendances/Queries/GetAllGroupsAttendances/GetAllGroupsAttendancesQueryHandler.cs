using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Campus.Persistence;
using Campus.Application.Attendances.Queries.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Campus.Application.Attendances.Queries.GetAllGroupsAttendances
{
    public class GetAllGroupsAttendancesQueryHandler : IRequestHandler<GetAllGroupsAttendancesQuery, ChartData>
    {
        private readonly CampusDbContext _context;

        public GetAllGroupsAttendancesQueryHandler(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<ChartData> Handle(GetAllGroupsAttendancesQuery request, CancellationToken cancellationToken)
        {
            var chartData = new ChartData();

            chartData.Data = await _context.Attendances
                .Include(x => x.Lesson)
                .ThenInclude(x => x.Group)
                .Where(x => x.Lesson.GroupId == request.GroupId 
                      && x.Date >= request.StartDate && x.Date <= request.EndDate)
                .Select(x => new ChartDataItem
                {
                    Date = x.Date,
                    AttendancePercentage = ((double)x.StudentsCount / x.Lesson.Group.StudentsCount) * 100
                }).ToListAsync();

            return chartData;
        }
    }
}

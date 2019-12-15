using System;
using Campus.Application.Attendances.Queries.DataTransferObjects;
using MediatR;

namespace Campus.Application.Attendances.Queries.GetAllGroupsAttendances
{
    public class GetAllGroupsAttendancesQuery : IRequest<ChartData>
    {
        public int GroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

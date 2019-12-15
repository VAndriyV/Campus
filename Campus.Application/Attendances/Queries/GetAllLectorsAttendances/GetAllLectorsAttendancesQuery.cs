using Campus.Application.Attendances.Queries.DataTransferObjects;
using MediatR;

using System;

namespace Campus.Application.Attendances.Queries.GetAllLectorsAttendances
{
    public class GetAllLectorsAttendancesQuery : IRequest<ChartData>
    {
        public int LectorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

using MediatR;

using Campus.Application.Attendances.Queries.DataTransferObjects;
using System;

namespace Campus.Application.Attendances.Queries.GetAllAttendances
{
    public class GetAllAttendancesQuery : IRequest<ChartData>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

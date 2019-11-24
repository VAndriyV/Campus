using MediatR;

using System;

namespace Campus.Application.Attendances.Queries.GetAllLectorsAttendances
{
    public class GetAllLectorsAttendancesQuery : IRequest<LectorsAttendancesListViewModel>
    {
        public int LectorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

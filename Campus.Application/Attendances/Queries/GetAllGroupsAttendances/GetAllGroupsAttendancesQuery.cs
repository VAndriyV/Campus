using System;

using MediatR;

namespace Campus.Application.Attendances.Queries.GetAllGroupsAttendances
{
    public class GetAllGroupsAttendancesQuery : IRequest<GroupsAttendancesListViewModel>
    {
        public int GroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

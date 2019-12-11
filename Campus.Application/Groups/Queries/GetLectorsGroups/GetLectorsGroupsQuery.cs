using MediatR;

namespace Campus.Application.Groups.Queries.GetLectorsGroups
{
    public class GetLectorsGroupsQuery : IRequest<LectorsGroupsListViewModel>
    {
        public int LectorId { get; set; }
    }
}

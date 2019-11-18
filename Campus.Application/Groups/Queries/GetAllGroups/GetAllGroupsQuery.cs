using MediatR;

namespace Campus.Application.Groups.Queries.GetAllGroups
{
    public class GetAllGroupsQuery : IRequest<GroupsListViewModel>
    {
    }
}

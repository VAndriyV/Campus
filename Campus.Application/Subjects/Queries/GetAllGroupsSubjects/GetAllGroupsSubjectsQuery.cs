using MediatR;

namespace Campus.Application.Subjects.Queries.GetAllGroupsSubjects
{
    public class GetAllGroupsSubjectsQuery : IRequest<GroupsSubjectsListViewModel>
    {
        public int GroupId { get; set; }
    }
}

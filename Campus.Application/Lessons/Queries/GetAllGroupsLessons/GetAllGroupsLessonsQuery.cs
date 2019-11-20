using MediatR;

namespace Campus.Application.Lessons.Queries.GetAllGroupsLessons
{
    public class GetAllGroupsLessonsQuery : IRequest<GroupsLessonsListViewModel>
    {
        public int GroupId { get; set; }
    }
}

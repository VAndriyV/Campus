using MediatR;

namespace Campus.Application.Lessons.Queries.GetLectorsLessonsByGroup
{
    public class GetLectorsLessonsByGroupQuery : IRequest<LectorsLessonByGroupListViewModel>
    {
        public int LectorId { get; set; }
        public int GroupId { get; set; }
    }
}

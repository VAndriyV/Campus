using MediatR;

namespace Campus.Application.Lessons.Queries.GetAllLectorsLessons
{
    public class GetAllLectorsLessonsQuery : IRequest<LectorsLessonsListViewModel>
    {
        public int LectorId { get; set; }
    }
}

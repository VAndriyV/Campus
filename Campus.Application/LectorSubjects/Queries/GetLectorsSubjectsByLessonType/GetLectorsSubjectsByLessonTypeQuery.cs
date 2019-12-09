using MediatR;

namespace Campus.Application.LectorSubjects.Queries.GetLectorsSubjectsByLessonType
{
    public class GetLectorsSubjectsByLessonTypeQuery : IRequest<LectorsSubjectsByLessonTypeListViewModel>
    {
        public int LectorId { get; set; }
        public int LessonTypeId { get; set; }
    }
}

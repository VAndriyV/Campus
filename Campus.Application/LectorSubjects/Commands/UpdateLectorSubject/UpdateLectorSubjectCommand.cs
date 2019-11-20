using MediatR;

namespace Campus.Application.LectorSubjects.Commands.UpdateLectorSubject
{
    public class UpdateLectorSubjectCommand : IRequest
    {
        public int Id { get; set; }
        public int LectorId { get; set; }
        public int SubjectId { get; set; }
        public int LessonTypeId { get; set; }
    }
}

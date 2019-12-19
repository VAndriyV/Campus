using MediatR;

namespace Campus.Application.LectorSubjects.Commands.CreateLectorSubject
{
    public class CreateLectorSubjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int LectorId { get; set; }
        public int SubjectId { get; set; }
        public int LessonTypeId { get; set; }
    }
}

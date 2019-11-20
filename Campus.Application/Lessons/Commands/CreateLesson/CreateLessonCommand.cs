using MediatR;

namespace Campus.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommand : IRequest
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LectorSubjectId { get; set; }
    }
}

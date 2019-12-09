using MediatR;

namespace Campus.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommand : IRequest
    {       
        public int GroupId { get; set; }
        public int LectorId { get; set; }
        public int SubjectId { get; set; }
        public int LessonTypeId { get; set; }
    }
}

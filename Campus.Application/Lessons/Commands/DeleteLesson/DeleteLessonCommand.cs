using MediatR;

namespace Campus.Application.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommand : IRequest
    {
        public int Id { get; set; }
    }
}

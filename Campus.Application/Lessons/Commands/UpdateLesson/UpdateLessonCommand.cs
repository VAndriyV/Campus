using MediatR;

namespace Campus.Application.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommand : IRequest
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LectorSubjectId { get; set; }
        
    }
}

using FluentValidation;

namespace Campus.Application.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonCommandValidator : AbstractValidator<DeleteLessonCommand>
    {
        public DeleteLessonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

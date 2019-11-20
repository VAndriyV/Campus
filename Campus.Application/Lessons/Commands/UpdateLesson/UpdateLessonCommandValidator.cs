using FluentValidation;

namespace Campus.Application.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandValidator : AbstractValidator<UpdateLessonCommand>
    {
        public UpdateLessonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.LectorSubjectId).NotEmpty();
            RuleFor(x => x.GroupId).NotEmpty();
        }
    }
}

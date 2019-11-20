using FluentValidation;

namespace Campus.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
    {
        public CreateLessonCommandValidator()
        {            
            RuleFor(x => x.LectorSubjectId).NotEmpty();
            RuleFor(x => x.GroupId).NotEmpty();
        }
    }
}

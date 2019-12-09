using FluentValidation;

namespace Campus.Application.Lessons.Commands.CreateLesson
{
    public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
    {
        public CreateLessonCommandValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
            RuleFor(x => x.LessonTypeId).NotEmpty();
            RuleFor(x => x.SubjectId).NotEmpty();
            RuleFor(x => x.GroupId).NotEmpty();
        }
    }
}

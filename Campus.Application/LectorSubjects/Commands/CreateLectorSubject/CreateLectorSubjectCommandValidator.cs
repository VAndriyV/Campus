using FluentValidation;

namespace Campus.Application.LectorSubjects.Commands.CreateLectorSubject
{
    public class CreateLectorSubjectCommandValidator : AbstractValidator<CreateLectorSubjectCommand>
    {
        public CreateLectorSubjectCommandValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
            RuleFor(x => x.SubjectId).NotEmpty();
            RuleFor(x => x.LessonTypeId).NotEmpty();
        }
    }
}

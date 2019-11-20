using FluentValidation;

namespace Campus.Application.LectorSubjects.Commands.UpdateLectorSubject
{
    public class UpdateLectorSubjectCommandValidator : AbstractValidator<UpdateLectorSubjectCommand>
    {
        public UpdateLectorSubjectCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.LectorId).NotEmpty();
            RuleFor(x => x.LessonTypeId).NotEmpty();
            RuleFor(x => x.SubjectId).NotEmpty();
        }
    }
}

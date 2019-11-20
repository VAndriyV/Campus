using FluentValidation;

namespace Campus.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
        }
    }
}

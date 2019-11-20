using FluentValidation;

namespace Campus.Application.LectorSubjects.Commands.DeleteLectorSubject
{
    public class DeleteLectorSubjectCommandValidator : AbstractValidator<DeleteLectorSubjectCommand>
    {
        public DeleteLectorSubjectCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

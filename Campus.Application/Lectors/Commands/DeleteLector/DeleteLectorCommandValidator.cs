using FluentValidation;

namespace Campus.Application.Lectors.Commands.DeleteLector
{
    public class DeleteLectorCommandValidator : AbstractValidator<DeleteLectorCommand>
    {
        public DeleteLectorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

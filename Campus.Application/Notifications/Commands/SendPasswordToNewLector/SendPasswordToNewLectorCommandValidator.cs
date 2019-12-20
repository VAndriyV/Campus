using FluentValidation;

namespace Campus.Application.Notifications.Commands.SendPasswordToNewLector
{
    public class SendPasswordToNewLectorCommandValidator : AbstractValidator<SendPasswordToNewLectorCommand>
    {
        public SendPasswordToNewLectorCommandValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();            
        }
    }
}

using FluentValidation;

namespace Campus.Application.Specialities.Commands.DeleteSpeciality
{
    public class DeleteSpecialityCommandValidator : AbstractValidator<DeleteSpecialityCommand>
    {
        public DeleteSpecialityCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

using FluentValidation;

namespace Campus.Application.Specialities.Commands.UpdateSpeciality
{
    public class UpdateSpecialityCommandValidator : AbstractValidator<UpdateSpecialityCommand>
    {
        public UpdateSpecialityCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}

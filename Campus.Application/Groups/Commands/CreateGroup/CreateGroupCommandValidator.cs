using FluentValidation;

namespace Campus.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(10).NotEmpty();
            RuleFor(x => x.SpecialityId).NotEmpty();
            RuleFor(x => x.EducationalDegreeId).NotEmpty();
            RuleFor(x => x.StudentsCount).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Year).GreaterThanOrEqualTo(1).LessThanOrEqualTo(4);
        }
    }
}

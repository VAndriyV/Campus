using FluentValidation;

namespace Campus.Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(10).NotEmpty();
            RuleFor(x => x.EducationalDegreeId).NotEmpty();
            RuleFor(x => x.StudentsCount).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Year).GreaterThanOrEqualTo(1).LessThanOrEqualTo(4);
        }
    }    
}

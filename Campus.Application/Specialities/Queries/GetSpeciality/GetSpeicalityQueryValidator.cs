using FluentValidation;

namespace Campus.Application.Specialities.Queries.GetSpeciality
{
    public class GetSpeicalityQueryValidator : AbstractValidator<GetSpecialityQuery>
    {
        public GetSpeicalityQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

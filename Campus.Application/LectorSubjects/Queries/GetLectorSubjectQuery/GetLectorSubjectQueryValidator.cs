using FluentValidation;

namespace Campus.Application.LectorSubjects.Queries.GetLectorSubjectQuery
{
    public class GetLectorSubjectQueryValidator : AbstractValidator<GetLectorSubjectQuery>
    {
        public GetLectorSubjectQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

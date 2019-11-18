using FluentValidation;

namespace Campus.Application.Lectors.Queries.GetLectorDetail
{
    public class GetLectorDetailQueryValidator : AbstractValidator<GetLectorDetailQuery>
    {
        public GetLectorDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

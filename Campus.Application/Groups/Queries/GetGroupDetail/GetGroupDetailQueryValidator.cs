using FluentValidation;

namespace Campus.Application.Groups.Queries.GetGroupDetail
{
    public class GetGroupDetailQueryValidator : AbstractValidator<GetGroupDetailQuery>
    {
        public GetGroupDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

using FluentValidation;

namespace Campus.Application.Groups.Queries.GetLectorsGroups
{
    public class GetLectorsGroupsQueryValidator : AbstractValidator<GetLectorsGroupsQuery>
    {
        public GetLectorsGroupsQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
        }
    }
}

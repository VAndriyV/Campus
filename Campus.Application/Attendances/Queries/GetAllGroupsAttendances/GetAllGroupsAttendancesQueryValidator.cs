using FluentValidation;

namespace Campus.Application.Attendances.Queries.GetAllGroupsAttendances
{
    public class GetAllGroupsAttendancesQueryValidator : AbstractValidator<GetAllGroupsAttendancesQuery>
    {
        public GetAllGroupsAttendancesQueryValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty();

            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();

            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate);
        }
    }
}

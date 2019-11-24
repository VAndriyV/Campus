using FluentValidation;

namespace Campus.Application.Attendances.Queries.GetAllGroupsAttendances
{
    public class GetAllGroupsAttendancesQueryValidator : AbstractValidator<GetAllGroupsAttendancesQuery>
    {
        public GetAllGroupsAttendancesQueryValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty();
        }
    }
}

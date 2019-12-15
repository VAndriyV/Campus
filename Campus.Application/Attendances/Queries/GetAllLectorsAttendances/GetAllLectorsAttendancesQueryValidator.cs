using FluentValidation;

namespace Campus.Application.Attendances.Queries.GetAllLectorsAttendances
{
    public class GetAllLectorsAttendancesQueryValidator : AbstractValidator<GetAllLectorsAttendancesQuery>
    {
        public GetAllLectorsAttendancesQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();

            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();

            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate);
        }
    }
}

using FluentValidation;

namespace Campus.Application.Attendances.Queries.GetAllLectorsAttendances
{
    public class GetAllLectorsAttendancesQueryValidator : AbstractValidator<GetAllLectorsAttendancesQuery>
    {
        public GetAllLectorsAttendancesQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
        }
    }
}

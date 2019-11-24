using FluentValidation;

namespace Campus.Application.LectorSubjects.Queries.GetAllLectorsSubjects
{
    public class GetAllLectorsSubjectsQueryValidator : AbstractValidator<GetAllLectorsSubjectsQuery>
    {
        public GetAllLectorsSubjectsQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
        }
    }
}

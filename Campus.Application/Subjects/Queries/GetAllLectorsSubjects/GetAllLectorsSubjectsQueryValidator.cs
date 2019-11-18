using FluentValidation;

namespace Campus.Application.Subjects.Queries.GetAllLectorsSubjects
{
    public class GetAllLectorsSubjectsQueryValidator : AbstractValidator<GetAllLectorsSubjectsQuery>
    {
        public GetAllLectorsSubjectsQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
        }
    }
}

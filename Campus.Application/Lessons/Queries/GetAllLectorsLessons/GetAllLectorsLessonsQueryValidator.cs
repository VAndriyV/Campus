using FluentValidation;

namespace Campus.Application.Lessons.Queries.GetAllLectorsLessons
{
    public class GetAllLectorsLessonsQueryValidator : AbstractValidator<GetAllLectorsLessonsQuery>
    {
        public GetAllLectorsLessonsQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
        }
    }
}

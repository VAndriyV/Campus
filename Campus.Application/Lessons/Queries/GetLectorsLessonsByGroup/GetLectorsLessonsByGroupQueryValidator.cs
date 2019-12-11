using FluentValidation;

namespace Campus.Application.Lessons.Queries.GetLectorsLessonsByGroup
{
    public class GetLectorsLessonsByGroupQueryValidator : AbstractValidator<GetLectorsLessonsByGroupQuery>
    {
        public GetLectorsLessonsByGroupQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
            RuleFor(x => x.GroupId).NotEmpty();
        }
    }
}

using FluentValidation;

namespace Campus.Application.Lessons.Queries.GetAllGroupsLessons
{
    public class GetAllGroupsLessonsQueryValidator : AbstractValidator<GetAllGroupsLessonsQuery>
    {
        public GetAllGroupsLessonsQueryValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty();
        }
    }
}

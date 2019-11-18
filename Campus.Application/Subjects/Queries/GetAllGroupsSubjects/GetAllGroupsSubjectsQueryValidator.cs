using FluentValidation;

namespace Campus.Application.Subjects.Queries.GetAllGroupsSubjects
{
    public class GetAllGroupsSubjectsQueryValidator : AbstractValidator<GetAllGroupsSubjectsQuery>
    {
        public GetAllGroupsSubjectsQueryValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty();
        }
    }
}

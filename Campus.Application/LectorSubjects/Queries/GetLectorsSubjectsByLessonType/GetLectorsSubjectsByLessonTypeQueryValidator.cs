using FluentValidation;


namespace Campus.Application.LectorSubjects.Queries.GetLectorsSubjectsByLessonType
{
    public class GetLectorsSubjectsByLessonTypeQueryValidator : AbstractValidator<GetLectorsSubjectsByLessonTypeQuery>
    {
        public GetLectorsSubjectsByLessonTypeQueryValidator()
        {
            RuleFor(x => x.LectorId).NotEmpty();
            RuleFor(x => x.LessonTypeId).NotEmpty();
        }
    }
}

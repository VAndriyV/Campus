using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Application.Lessons.Queries.GetLesson
{
    public class GetLessonQueryValidator : AbstractValidator<GetLessonQuery>
    {
        public GetLessonQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

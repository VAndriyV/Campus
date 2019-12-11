using Campus.Application.Lessons.Queries.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Application.Lessons.Queries.GetLesson
{
    public class GetLessonQuery : IRequest<LessonDto>
    {
        public int Id { get; set; }
    }
}

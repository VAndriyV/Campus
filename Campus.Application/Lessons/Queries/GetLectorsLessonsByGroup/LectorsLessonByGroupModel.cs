
using Campus.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Campus.Application.Lessons.Queries.GetLectorsLessonsByGroup
{
    public class LectorsLessonByGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Lesson, LectorsLessonByGroupModel>> Projection
        {
            get
            {
                return x => new LectorsLessonByGroupModel
                {
                    Id = x.LectorSubjectId,
                    Name = $"{x.LectorSubject.Subject.Name} ({x.LectorSubject.LessonType.Name})"
                };
            }
        }
    }
}

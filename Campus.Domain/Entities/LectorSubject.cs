using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class LectorSubject
    {
        public int Id { get; set; }
        public int LectorId { get; set; }
        public int SubjectId { get; set; }
        public int LessonTypeId { get; set; }

        public Lector Lector { get; set; }
        public Subject Subject { get; set; }
        public LessonType LessonType { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}

using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LectorSubjectId { get; set; }

        public Group Group { get; set; }
        public LectorSubject LectorSubject { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}

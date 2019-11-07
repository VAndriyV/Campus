using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class DayOfWeek
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}

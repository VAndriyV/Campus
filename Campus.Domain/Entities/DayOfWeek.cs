using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class DayOfWeek
    {
        public DayOfWeek()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }
    }
}

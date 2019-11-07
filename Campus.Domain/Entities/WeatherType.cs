using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class WeatherType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Attendance> Attendances { get; set; }        
    }
}

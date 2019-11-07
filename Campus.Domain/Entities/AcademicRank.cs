using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class AcademicRank
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Lector> Lectors { get; set; }
    }
}

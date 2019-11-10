using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class AcademicDegree
    {
        public AcademicDegree()
        {
            Lectors = new HashSet<Lector>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Lector> Lectors { get; private set; }
    }
}

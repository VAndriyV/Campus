using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class Subject
    {
        public Subject()
        {
            LectorSubjects = new HashSet<LectorSubject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<LectorSubject> LectorSubjects { get;private set; }
    }
}

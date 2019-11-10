using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class EducationalDegree
    {
        public EducationalDegree()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Groups { get; private set; }
    }
}

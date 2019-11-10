using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class Speciality
    {
        public Speciality()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public ICollection<Group> Groups { get; private set; }
    }
}

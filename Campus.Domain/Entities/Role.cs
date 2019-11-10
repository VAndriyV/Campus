
using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; }
    }
}

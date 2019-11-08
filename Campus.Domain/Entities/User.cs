using System;
using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastVisit { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public Lector Lector { get; set; }
    }
}

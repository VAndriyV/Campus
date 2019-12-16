using System.Collections.Generic;

namespace Campus.Application.Users.Queries.DataTransferObjects
{
    public class UserDto
    {
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public int? LectorId { get; set; }
    }
}

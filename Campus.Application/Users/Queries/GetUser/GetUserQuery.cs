using MediatR;

using Campus.Application.Users.Queries.DataTransferObjects;

namespace Campus.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

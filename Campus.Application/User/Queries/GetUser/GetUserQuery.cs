using MediatR;

using Campus.Application.User.Queries.DataTransferObjects;

namespace Campus.Application.User.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

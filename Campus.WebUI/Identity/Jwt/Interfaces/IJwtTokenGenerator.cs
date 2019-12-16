using Campus.Application.Users.Queries.DataTransferObjects;
using Campus.WebUI.Identity.Jwt.Models;

namespace Campus.WebUI.Identity.Jwt.Interfaces
{
    public interface IJwtTokenGenerator
    {
        JwtTokenResult Generate(UserDto user);
    }
}

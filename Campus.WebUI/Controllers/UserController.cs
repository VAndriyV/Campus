using Campus.Application.Notifications.Commands.SendResetedPassword;
using Campus.Application.Users.Commands.ResetUserPassword;
using Campus.Application.Users.Queries.GetUser;
using Campus.WebUI.Identity.Jwt.Interfaces;
using Campus.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Campus.WebUI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserController(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("session")]
        public async Task<IActionResult> Session([FromBody] UserCredentials credentials)
        {
            var user = await Mediator.Send(new GetUserQuery { Email = credentials.Email, Password =  credentials.Password });
            var tokenResult = _jwtTokenGenerator.Generate(user);            
            HttpContext.Response.Cookies.Append(
                ".AspNetCore.Application.Id",
                tokenResult.AccessToken,
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(10080) });

            return Ok(user);
        }

        [HttpDelete("session")]
        public IActionResult Session()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");
            return NoContent();
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetUserPasswordCommand command)
        {
            var (id, password) = await Mediator.Send(command);

            return Ok(await Mediator.Send(new SendResetedPasswordCommand { UserId = id, Password = password }));            
        }
    }
}

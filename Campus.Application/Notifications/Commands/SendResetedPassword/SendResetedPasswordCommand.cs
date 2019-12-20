using MediatR;

namespace Campus.Application.Notifications.Commands.SendResetedPassword
{
    public class SendResetedPasswordCommand : IRequest
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}

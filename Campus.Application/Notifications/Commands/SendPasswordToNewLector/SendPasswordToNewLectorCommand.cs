using MediatR;

namespace Campus.Application.Notifications.Commands.SendPasswordToNewLector
{
    public class SendPasswordToNewLectorCommand : IRequest
    {
        public int LectorId { get; set; }
        public string Password { get; set; }
    }
}

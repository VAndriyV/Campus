using MediatR;

namespace Campus.Application.Users.Commands.ResetUserPassword
{
    public class ResetUserPasswordCommand : IRequest<(int, string)>
    {
        public string Email { get; set; }        
    }
}

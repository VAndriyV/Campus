using Campus.Application.Interfaces;
using Campus.Application.Notifications.Models;
using Campus.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Notifications.Commands.SendResetedPassword
{
    public class SendResetedPasswordCommandHandler : IRequestHandler<SendResetedPasswordCommand, Unit>
    {
        private readonly CampusDbContext _context;
        private readonly INotificationService _notificationService;

        public SendResetedPasswordCommandHandler(CampusDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(SendResetedPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);

            var message = new Message
            {
                Body = GenerateMessageBody(user.Email, request.Password),
                From = "campus@mail.com",
                Subject = "Password reset",
                To = user.Email
            };

            await _notificationService.SendMessageAsync(message);

            return Unit.Value;
        }

        private string GenerateMessageBody(string email, string password)
        {
            return $"Your credentials for Campus system: Email - {email}, Password - {password}";
        }
    }
}

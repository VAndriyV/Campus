using Campus.Application.Interfaces;
using Campus.Application.Notifications.Models;
using Campus.Domain.Entities;
using Campus.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.Notifications.Commands.SendPasswordToNewLector
{
    public class SendPasswordToNewLectorCommandHandler : IRequestHandler<SendPasswordToNewLectorCommand, Unit>
    {
        private readonly CampusDbContext _context;
        private readonly INotificationService _notificationService;

        public SendPasswordToNewLectorCommandHandler(CampusDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(SendPasswordToNewLectorCommand request, CancellationToken cancellationToken)
        {
            var lector = await _context.Lectors.FindAsync(request.LectorId);

            var message = new Message
            {
                Body = GenerateMessageBody(lector, request.Password),
                From = "campus@mail.com",
                Subject = "Credentials for login to Campus",
                To = lector.Email
            };

            await _notificationService.SendMessageAsync(message);

            return Unit.Value;
        }

        private string GenerateMessageBody(Lector lector, string password)
        {
            return $"Dear, {lector.LastName} {lector.FirstName} {lector.Patronymic}, your credentials for Campus system: Email - {lector.Email}, Password - {password}";
        }
    }
}

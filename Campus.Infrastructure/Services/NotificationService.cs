using Campus.Application.Interfaces;
using Campus.Application.Notifications.Models;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Campus.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendMessageAsync(Message message)
        {
            using var client = new SmtpClient("127.0.0.1");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(message.From);
            mailMessage.To.Add(message.To);
            mailMessage.Body = message.Body;
            mailMessage.Subject = message.Body;
            await client.SendMailAsync(mailMessage);
        }
    }
}

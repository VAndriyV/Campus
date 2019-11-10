using System.Threading.Tasks;
using Campus.Application.Notifications.Models;

namespace Campus.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendMessageAsync(Message message);
    }
}

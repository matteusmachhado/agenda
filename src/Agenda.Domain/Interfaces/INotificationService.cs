using Agenda.Entities.DTOs;

namespace Agenda.Domain.Interfaces
{
    public interface INotificationService
    {
        bool HasNotification();
        List<Notification> Notifications();
        void Handle(Notification notification);
    }
}

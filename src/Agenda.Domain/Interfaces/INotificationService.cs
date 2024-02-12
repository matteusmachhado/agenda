using Agenda.Shared.DTOs;

namespace Agenda.Domain.Interfaces
{
    public interface INotificationService
    {
        bool HasNotification();
        List<NotificationDto> Notifications();
        void Handle(NotificationDto notification);
    }
}

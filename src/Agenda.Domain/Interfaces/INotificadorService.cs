using Agenda.Domain.DTO;

namespace Agenda.Domain.Interfaces
{
    public interface INotificadorService
    {
        bool HasNotification();
        List<Notification> Notifications();
        void Handle(Notification notificacao);
    }
}

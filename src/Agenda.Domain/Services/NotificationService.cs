using Agenda.Entities.DTOs;
using Agenda.Domain.Interfaces;

namespace Agenda.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _notificacoes;

        public NotificationService()
        {
            _notificacoes = new List<Notification>();
        }

        public void Handle(Notification notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notification> Notifications()
        {
            return _notificacoes;
        }

        public bool HasNotification()
        {
            return _notificacoes.Any();
        }
    }
}

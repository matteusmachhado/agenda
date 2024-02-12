using Agenda.Shared.DTOs;
using Agenda.Domain.Interfaces;

namespace Agenda.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private List<NotificationDto> _notificacoes;

        public NotificationService()
        {
            _notificacoes = new List<NotificationDto>();
        }

        public void Handle(NotificationDto notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<NotificationDto> Notifications()
        {
            return _notificacoes;
        }

        public bool HasNotification()
        {
            return _notificacoes.Any();
        }
    }
}

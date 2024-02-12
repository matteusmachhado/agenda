
namespace Agenda.Shared.DTOs
{
    public class NotificationDto
    {
        public string Mensagem { get; }

        public NotificationDto(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}

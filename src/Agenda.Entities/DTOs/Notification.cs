
namespace Agenda.Entities.DTOs
{
    public class Notification
    {
        public string Mensagem { get; }

        public Notification(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}

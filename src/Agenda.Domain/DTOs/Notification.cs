using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.DTOs
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

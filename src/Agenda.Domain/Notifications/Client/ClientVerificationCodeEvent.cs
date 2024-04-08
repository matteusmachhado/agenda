using Agenda.Domain.Core.Messages;
using Agenda.Shared.Enums;

namespace Agenda.Domain.Notifications.Client
{
    public class ClientVerificationCodeEvent : Event
    {
        public TypeOfCheckEnum TypeOfCheck { get; private set; }
        public string From { get; private set; }

        public ClientVerificationCodeEvent(TypeOfCheckEnum typeOfCheck, string from)
        {
            TypeOfCheck = typeOfCheck;
            From = from;
        }
    }
}

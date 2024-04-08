using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Notifications.Client
{
    public class ClientEventHandler : INotificationHandler<ClientVerificationCodeEvent>
    {
        public Task Handle(ClientVerificationCodeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

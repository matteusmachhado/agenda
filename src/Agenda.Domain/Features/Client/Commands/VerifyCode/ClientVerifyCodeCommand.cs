
using MediatR;

namespace Agenda.Domain.Features.Client.Commands.VerifyCode
{
    public class ClientVerifyCodeCommand : IRequest<string>
    {
        public string Code { get; set; }
    }
}

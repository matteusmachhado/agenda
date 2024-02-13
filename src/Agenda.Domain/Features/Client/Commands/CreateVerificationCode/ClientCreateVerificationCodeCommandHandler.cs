using Agenda.Data.Interfaces;
using Agenda.Domain.Features.Client.Commands.CreateVerificationCode;
using Agenda.Shared.Enums;
using Agenda.Shared.Utils;
using MediatR;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCode
{
    public class ClientCreateVerificationCodeCommandHandler : BaseCommandHandler, 
        IRequestHandler<ClientCreateVerificationCodeCommand, ClientCreateVerificationCodeResponse>
    {

        public ClientCreateVerificationCodeCommandHandler(IUnitOfWork _uow) : base(_uow)
        {

        }

        public Task<ClientCreateVerificationCodeResponse> Handle(ClientCreateVerificationCodeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Task.FromResult(new ClientCreateVerificationCodeResponse(request.ValidationResult));

            var code = GenerateCode(request.TypeVerificarionCode);

            return Task.FromResult(new ClientCreateVerificationCodeResponse(code));
        }

        public string GenerateCode(TypeVerificarionCodeEnum type) => type switch
        {
            TypeVerificarionCodeEnum.Numeric => RandomUtil.Numeric(5),
            TypeVerificarionCodeEnum.AlphaNumeric => RandomUtil.AlphaNumeric(5),
            _ => throw new NotImplementedException()
        };
    }
}

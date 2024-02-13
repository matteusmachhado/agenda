using Agenda.Data.Interfaces;
using Agenda.Domain.Features.Client.Commands.CreateVerificationCode;
using Agenda.Shared.Enums;
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

            var code = GenerateCode(request.TypeCodeVerify);

            return Task.FromResult(new ClientCreateVerificationCodeResponse(code));
        }

        public string GenerateCode(TypeCodeVerifyEnum type) => type switch
        {
            TypeCodeVerifyEnum.Numeric => RandomNumeric(),
            TypeCodeVerifyEnum.AlphaNumeric => RandomAlphaNumeric(),
            _ => throw new NotImplementedException()
        };
        

        private string RandomAlphaNumeric()
        {
            var length = 5;
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string RandomNumeric()
        {
            var code = new Random().Next(10000, 99999);
            return code.ToString();
        }
    }
}

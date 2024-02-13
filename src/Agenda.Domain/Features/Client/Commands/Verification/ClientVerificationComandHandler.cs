using Agenda.Data.Interfaces;
using Agenda.WebApi.Configurations;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Agenda.Domain.Features.Client.Commands.SendSMS
{
    public class ClientVerificationComandHandler : BaseCommandHandler, IRequestHandler<ClientVerificationComand, ValidationResult>
    {
        private readonly TwilioSetting _twilioSetting;

        public ClientVerificationComandHandler(IUnitOfWork _uow,
            IOptions<TwilioSetting> twilioSetting
            ) : base(_uow)
        {
            _twilioSetting = twilioSetting.Value;
        }

        public async Task<ValidationResult> Handle(ClientVerificationComand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            TwilioClient.Init(_twilioSetting.AccountSID, _twilioSetting.AuthToken);

            var code = new Random().Next(10000, 99999);

            var message = await MessageResource.CreateAsync(
                body: $"{code} é seu código de login.",
                from: new Twilio.Types.PhoneNumber(_twilioSetting.SMSSernderNumber),
                to: new Twilio.Types.PhoneNumber(request.PhoneNumber)
            );

            return request.ValidationResult;
        }
    }
}

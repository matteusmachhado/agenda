using Agenda.Data.Interfaces;
using Agenda.WebApi.Configurations;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Agenda.Domain.Features.Client.Commands.SendSMS
{
    public class ClientSendSMSComandHandler : BaseCommandHandler, IRequestHandler<ClientSendSMSComand, ValidationResult>
    {

        private readonly TwilioSetting _twilioSetting;

        public ClientSendSMSComandHandler(IUnitOfWork _uow,
            IOptions<TwilioSetting> twilioSetting
            ) : base(_uow)
        {
            _twilioSetting = twilioSetting.Value;
        }

        public async Task<ValidationResult> Handle(ClientSendSMSComand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            TwilioClient.Init(_twilioSetting.AccountSID, _twilioSetting.AuthToken);

            var message = await MessageResource.CreateAsync(
                body: request.Description,
                from: new Twilio.Types.PhoneNumber(_twilioSetting.SMSSernderNumber),
                to: new Twilio.Types.PhoneNumber(request.Phone)
            );

            return request.ValidationResult;
        }
    }
}

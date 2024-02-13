﻿using Agenda.Domain.Interfaces;
using Agenda.Shared.Settings;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Agenda.Domain.Services
{
    public class TwilioService : ITwilioService
    {
        private readonly TwilioSetting _twilioSetting;

        public TwilioService(IOptions<TwilioSetting> twilioSetting)
        {
            _twilioSetting = twilioSetting.Value;
        }

        public async Task SendVerificationCode(string code, string phoneNumber)
        {
            TwilioClient.Init(_twilioSetting.AccountSID, _twilioSetting.AuthToken);

            var message = await MessageResource.CreateAsync(
                body: $"{code} é seu código de login.",
                from: new Twilio.Types.PhoneNumber(_twilioSetting.SMSSernderNumber),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }
    }
}

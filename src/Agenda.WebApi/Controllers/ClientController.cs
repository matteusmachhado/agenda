using Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail;
using Agenda.Domain.Features.Client.Commands.SendVerificationCodeSMS;
using Agenda.Domain.Features.Client.Commands.VerifyCode;
using Agenda.Domain.Interfaces;
using Agenda.Shared.Settings;
using Agenda.Shared.Utils;
using Agenda.Shared.ViewModels.Auth;
using Agenda.WebApi.Middlewares;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agenda.WebApi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client")]
    public class ClientController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly JwtSetting _jwtSetting;

        public ClientController(INotificationService notifier,
            IMediator mediator,
            IUser user,
            IOptions<JwtSetting> jwtSetting) : base(notifier, user)
        {
            _mediator = mediator;
            _jwtSetting = jwtSetting.Value;
        }

        [AllowAnonymous]
        [Transaction]
        [HttpPost("send-verification-code-sms")]
        public async Task<ActionResult> SendVerificationCodeSMS(ClientSendVerificationCodeSMSCommand clientSendVerificationCodeCommand)
        {
            var result = await _mediator.Send(clientSendVerificationCodeCommand);

            return CustomResponse(result);
        }

        [AllowAnonymous]
        [Transaction]
        [HttpPost("send-verification-code-email")]
        public async Task<ActionResult> SendVerificationCodeEmail(ClientSendVerificationCodeEmailCommand clientSendVerificationCodeEmailCommand)
        {
            var result = await _mediator.Send(clientSendVerificationCodeEmailCommand);

            return CustomResponse(result);
        }

        [AllowAnonymous]
        [Transaction]
        [HttpPost("verify")]
        public async Task<ActionResult> Verify(ClientVerifyCodeCommand clientVerifyCodeCommand)
        {
            var phoneNumberOrEmail = await _mediator.Send(clientVerifyCodeCommand);

            return CustomResponse(GenerateJwt(phoneNumberOrEmail));
        }

        private LoginResponseViewModel GenerateJwt(string phoneNumberOrEmail)
        {
            if(string.IsNullOrEmpty(phoneNumberOrEmail)) return null;

            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, phoneNumberOrEmail));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToUnixEpochDate().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUnixEpochDate().ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSetting.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSetting.Emissor,
                Audience = _jwtSetting.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_jwtSetting.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_jwtSetting.ExpiracaoHoras).TotalSeconds
            };

            return response;
        }
    }
}

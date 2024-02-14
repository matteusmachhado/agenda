using Agenda.Data.Interfaces;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Domain.Features.Client.Queries.FindVerificationCode
{
    public class ClientFindVerificationCodeQueryHendler : IRequestHandler<ClientFindVerificationCodeQuery, ClientFindVerificationCodeResponse>
    {
        private readonly IVerificationCodeRepository _verificationCodeRepository;

        public ClientFindVerificationCodeQueryHendler(IVerificationCodeRepository verificationCodeRepository)
        {
            _verificationCodeRepository = verificationCodeRepository;
        }

        public async Task<ClientFindVerificationCodeResponse> Handle(ClientFindVerificationCodeQuery request, CancellationToken cancellationToken)
        {
            return new ClientFindVerificationCodeResponse(request.ValidationResult);
        }
    }
}

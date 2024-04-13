using Agenda.Data.Interfaces;
using Agenda.Shared.Enums;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Domain.Features.Client.Commands.Create
{
    public class CreateCommandHandler : BaseCommandHandler, IRequestHandler<CreateCommand, ValidationResult>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateCommandHandler(IUnitOfWork uow,
            UserManager<IdentityUser> userManager) : base(uow)
        {
            _userManager = userManager;
        }

        public async Task<ValidationResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var user = new IdentityUser
            {
                UserName = Guid.NewGuid().ToString()
            };

            switch (request.TypeOfCheck)
            {
                case TypeOfCheckEnum.SMS:
                    user.PhoneNumber = request.From;
                    user.PhoneNumberConfirmed = true;
                    break;
                case TypeOfCheckEnum.Email: 
                    user.Email = request.From;
                    user.EmailConfirmed = true;
                    break;
            }

            // adicionar validação por phonenumber

            await _userManager.CreateAsync(user);

            return request.ValidationResult;
        }
    }
}

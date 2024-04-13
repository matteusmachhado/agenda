using Agenda.Entities;
using Agenda.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Notifications.Client
{
    public class ClientEventHandler : INotificationHandler<ClientVerificationCodeEvent>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ClientEventHandler(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Handle(ClientVerificationCodeEvent notification, CancellationToken cancellationToken)
        {
            var client = await FindClientUserAsync(notification.TypeOfCheck, notification.From);
            if (client is not null)
            {
                await _signInManager.SignInAsync(client, false);
            }
        }

        private async Task<IdentityUser> FindClientUserAsync(TypeOfCheckEnum typeOfCheck, string from)
        {
            IdentityUser user = null;

            switch (typeOfCheck)
            {
                case TypeOfCheckEnum.SMS:
                    user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber != null && u.PhoneNumber.Equals(from));
                    break;
                case TypeOfCheckEnum.Email:
                    user = await _userManager.FindByEmailAsync(from);
                    break;
            }

            return user;
        }
    }
}

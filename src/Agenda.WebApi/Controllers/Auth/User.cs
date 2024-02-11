using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Agenda.Domain.Interfaces;
using IdentityModel;

namespace Agenda.WebApi.Controllers.Auth
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid GetUserId()
        {
            if (!IsAuthenticated()) return Guid.Empty;

            var claim = _accessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            return claim is null ? Guid.Empty : Guid.Parse(claim);
        }

        public string GetUserName()
        {
            var userName = _accessor.HttpContext?.User.FindFirst(JwtClaimTypes.Name)?.Value;
            if (!string.IsNullOrEmpty(userName)) return userName;

            return string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext?.User.Identity is { IsAuthenticated: true };
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext != null && _accessor.HttpContext.User.IsInRole(role);
        }

        public string GetLocalIpAddress()
        {
            return _accessor.HttpContext?.Connection.LocalIpAddress?.ToString();
        }

        public string GetRemoteIpAddress()
        {
            return _accessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
        }
    }
}

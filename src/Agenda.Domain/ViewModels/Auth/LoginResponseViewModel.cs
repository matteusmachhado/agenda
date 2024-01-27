namespace Agenda.Domain.ViewModels.Auth
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Agenda.Shared.Settings
{
    public class UserDefaultSettings
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

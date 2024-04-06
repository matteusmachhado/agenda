using System.ComponentModel.DataAnnotations;

namespace Agenda.Shared.Settings
{
    public record TwilioSettings()
    {
        [Required]
        public string AccountSID { get; set; }
        [Required]
        public string AuthToken { get; set; }
        [Required]
        public string SMSSernderNumber { get; set; }
    }
}

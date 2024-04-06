using System.ComponentModel.DataAnnotations;

namespace Agenda.Shared.Settings
{
    public class EmailSettings
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string Host { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public bool EnableSsl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Agenda.Shared.Settings
{
    public class VerificationCodeSettings
    {
        [Required]
        public int CaracteresLength  { get; set; }
        [Required]
        public int Timer { get; set; }
    }
}

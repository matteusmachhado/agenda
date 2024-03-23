using System.ComponentModel.DataAnnotations;

namespace Agenda.Shared.Settings
{
    public class VerificationCodeSetting
    {
        [Required]
        public int CaracteresLength  { get; set; }
        [Required]
        public int Timer { get; set; }
    }
}

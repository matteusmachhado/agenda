using System.ComponentModel.DataAnnotations;

namespace Agenda.Shared.Settings
{
    public class JwtSetting
    {
        [Required]
        public string Secret { get; set; }
        [Required]
        public int ExpiracaoHoras { get; set; }
        [Required]
        public string Emissor { get; set; }
        [Required]
        public string ValidoEm { get; set; }
    }
}

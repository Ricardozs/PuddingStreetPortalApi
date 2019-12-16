using System.ComponentModel.DataAnnotations;

namespace PortalApi.DTO
{
    public class LogInData
    {
        [Required]
        [MaxLength(140)]
        public string User { get; set; }
        public string Password { get; set; }
    }
}

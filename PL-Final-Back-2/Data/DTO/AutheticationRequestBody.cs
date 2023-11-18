
using System.ComponentModel.DataAnnotations;

namespace Agenda_Tup_Back.DTO
{
    public class AuthenticationRequestBody
    {
        [MaxLength(500)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

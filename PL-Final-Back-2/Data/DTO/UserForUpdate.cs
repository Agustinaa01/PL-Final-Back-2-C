using System.ComponentModel.DataAnnotations;
using Agenda_Tup_Back.Models.Enum;

namespace Agenda_Tup_Back.DTO
{
    public class UserForUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

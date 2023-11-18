using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agenda_Tup_Back.Models.Enum;

namespace Agenda_Tup_Back.Entities
{
    public class User
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Id unico, se autogenera
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public string? Email { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
        public Rol Rol { get; set; } = Rol.User;
        public State state { get; set; } = State.Active;
    }
}

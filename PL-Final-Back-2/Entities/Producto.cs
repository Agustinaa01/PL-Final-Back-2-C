using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Agenda_Tup_Back.Models.Enum;

namespace Agenda_Tup_Back.Entities
{
    public class Producto
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public string ImageUrl { get; set; }
        //[JsonIgnore]
        public int? PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public State state { get; set; } = State.Active;
        //[JsonIgnore]
        //public ICollection<Pedido> Pedido { get; set; }

    }

}

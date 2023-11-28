using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Agenda_Tup_Back.Entities
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<PedidoProducto> PedidoProductos { get; set; } = new List<PedidoProducto>();
    }
}


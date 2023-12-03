using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Agenda_Tup_Back.Models.Enum;

namespace Agenda_Tup_Back.Entities
{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public State state { get; set; } = State.Active;

        // This should be a collection of PedidoProducto
        [JsonIgnore]
        public ICollection<PedidoProducto> PedidoProductos { get; set; } = new List<PedidoProducto>();
    }

}

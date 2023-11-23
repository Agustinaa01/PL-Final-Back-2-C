using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.DTO
{
    public class PedidoForCreation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }
        //public ICollection<ProductoForCreation> Producto { get; set; } = new List<ProductoForCreation>();
    }

}

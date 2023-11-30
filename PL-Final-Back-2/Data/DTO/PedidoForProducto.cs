using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.DTO
{
    public class PedidoForProducto
    {
        public int PedidoId { get; set; }
        public List<int> ProductoId { get; set; }

    }
}
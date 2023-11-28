using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Entities
{
    public class PedidoProducto
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
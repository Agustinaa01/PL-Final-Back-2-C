using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.DTO
{
    public class PedidoProductoDto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public ProductoDto Producto { get; set; }
    }

}
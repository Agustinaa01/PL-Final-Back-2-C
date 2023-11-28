namespace Agenda_Tup_Back.Data.DTO
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }

        // This should be a collection of ProductoDto
        public ICollection<PedidoProductoDto> PedidoProductos { get; set; } = new List<PedidoProductoDto>();
    }

}

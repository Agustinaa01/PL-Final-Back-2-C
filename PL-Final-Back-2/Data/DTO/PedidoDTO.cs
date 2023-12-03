namespace Agenda_Tup_Back.Data.DTO
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }

        public ICollection<PedidoProductoGetDto> PedidoProductos { get; set; } = new List<PedidoProductoGetDto>();
    }

}

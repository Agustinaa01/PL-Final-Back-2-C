namespace Agenda_Tup_Back.Data.DTO
{
    public class PedidoProductoGetDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public ProductoDto Producto
        {
            get; set;
        }
    }

}

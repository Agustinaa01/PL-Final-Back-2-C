using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.DTO
{
    public class PedidoForUpdate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public List<int> ProductoId { get; set; }
    }


}

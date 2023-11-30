using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IPedidoRepository
    {
        public List<Pedido> GetAllPedido(int id);
        //public List<Pedido> GetAllPedido(int id);
        public Pedido? GetPedido(int id);
        public List<PedidoDto>? GetPedidosByUserId(int Id);

        public Pedido CreatePedido(PedidoForCreation dto);
        public List<PedidoProducto> AddProducto(PedidoForProducto dto);
        public void UpdatePedido(PedidoForUpdate dto);
        public void DeletePedido(int id);
       

    }
}

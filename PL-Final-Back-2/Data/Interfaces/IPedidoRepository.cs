﻿using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IPedidoRepository
    {
        public List<Pedido> GetAllPedido(int id);
        //public List<Pedido> GetAllPedido(int id);
        public Pedido? GetPedidoById(int Id);
        public void CreatePedido(PedidoForCreation dto);
        public void AddProducto(PedidoForUpdate dto);
        public void DeletePedido(int id);

    }
}

using System.Text.Json.Serialization;
using System.Text.Json;
using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agenda_Tup_Back.DTO;
using System.Text.RegularExpressions;

namespace Agenda_Tup_Back.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;
        public PedidoRepository(AgendaApiContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }
        public List<Pedido> GetAllPedido(int id)
        {
            var pedido = _context.Pedido
                .ToList();
            return pedido;
        }

        public List<PedidoDto> GetPedidosByUserId(int userId)
        {
            var pedidos = _context.Pedido
                .Include(p => p.PedidoProductos)
                    .ThenInclude(pp => pp.Producto) // Include the related Producto entity
                .Where(p => p.UserId == userId)
                .ToList();

            return _mapper.Map<List<PedidoDto>>(pedidos);
        }

        public Pedido? GetPedido(int id)
        {
            return _context.Pedido.SingleOrDefault(u => u.Id == id);
        }

        public Pedido CreatePedido(PedidoForCreation dto)
        {
            var newPedido = _mapper.Map<Pedido>(dto);
            _context.Pedido.Add(newPedido);
            _context.SaveChanges();

            return newPedido;
        }

        public void AddProducto(PedidoForUpdate dto)
        {
            var producto = _context.Producto
                .Where(p => p.Id == dto.ProductoId)
                .FirstOrDefault();

            var pedido = _context.Pedido.Find(dto.PedidoId);

            if (producto != null && pedido != null)
            {
                var pedidoProducto = _mapper.Map<PedidoProducto>(dto);
                pedido.PedidoProductos.Add(pedidoProducto);
                producto.PedidoProductos.Add(pedidoProducto);

                _context.SaveChanges();
            }
        }



        public void DeletePedido(int Id)
        {
            var pedido = _context.Pedido.Single(c => c.Id == Id);

            _context.Pedido.Remove(pedido);

            _context.SaveChanges();
        }


    }


}

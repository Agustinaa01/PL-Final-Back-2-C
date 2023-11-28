﻿
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
            var pedido = _context.Pedido.Include(p => p.PedidoProductos).FirstOrDefault(p => p.Id == dto.PedidoId);

            if (pedido != null)
            {
                var productos = _context.Producto.Where(p => dto.ProductoId.Contains(p.Id)).ToList();

                foreach (var producto in productos)
                {
                    var pedidoProducto = new PedidoProducto
                    {
                        PedidoId = dto.PedidoId,
                        ProductoId = producto.Id
                    };

                    pedido.PedidoProductos.Add(pedidoProducto);
                }

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

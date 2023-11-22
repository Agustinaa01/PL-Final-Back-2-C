
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
        private readonly EcommerceApiContext _context;
        private readonly IMapper _mapper;
        public PedidoRepository(EcommerceApiContext context, IMapper autoMapper)
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
  
        //public async Task<IActionResult> GetPedidos(int id)
        //{
        //    var pedidos = await _context.Pedido.Include(p => p.Producto).ToListAsync();

        //    var jsonSettings = new JsonSerializerOptions
        //    {
        //        ReferenceHandler = ReferenceHandler.Preserve,
        //        // Otros ajustes según sea necesario
        //    };

        //    var jsonResult = JsonSerializer.Serialize(pedidos, jsonSettings);

        //    return Ok(jsonResult);
        //}

        //public List<Pedido> GetAllGroupsNames(int id)
        //{
        //    return _context.Groups.ToList();
        //}

        public Pedido? GetPedidoById(int Id)
        {
            var pedido = _context.Pedido
                .Include(c => c.Producto)
                .SingleOrDefault(u => u.Id == Id);
            return pedido;
        }
        //public void CreatePedido(PedidoForCreation dto)
        //{
        //    _context.Pedido.Add(_mapper.Map<Pedido>(dto));
        //    _context.SaveChanges();
        //}
        public void CreatePedido(PedidoForCreation dto)
        {
            _context.Pedido.Add(_mapper.Map<Pedido>(dto));
            _context.SaveChanges();
        }

        //public void AddProducto(PedidoForUpdate dto)
        //{
        //    var contact = _context.Producto
        //        .Where(c => c.Id == dto.ProductoId)
        //        .Include(c => c.Pedido)
        //        .FirstOrDefault();
        //    var group = _context.Pedido.Find(dto.PedidoId);
        //    contact.Pedido.Add(group);
        //    _context.SaveChanges();
        //}
        public void AddProducto(PedidoForUpdate dto)
        {
            var producto = _context.Producto
                .Where(p => p.Id == dto.ProductoId)
                .FirstOrDefault();

            var pedido = _context.Pedido.Find(dto.PedidoId);

            if (producto != null && pedido != null)
            {
                // Asigna el PedidoId al Producto
                producto.PedidoId = pedido.Id;

                // Añade el producto al pedido (si no está ya presente)
                if (!pedido.Producto.Any(p => p.Id == producto.Id))
                {
                    pedido.Producto.Add(producto);
                }

                _context.SaveChanges();
            }
        }

        public void DeletePedido(int Id)
        {
            _context.Pedido.Remove(_context.Pedido.Single(c => c.Id == Id));
            _context.SaveChanges();
        }

    }


}

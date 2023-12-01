
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
        public List<PedidoDto> GetAllPedido(int id)
        {
            var pedidos = _context.Pedido
                .Include(p => p.PedidoProductos)
                    .ThenInclude(pp => pp.Producto) // Include the related Producto entity
                .ToList();

            return _mapper.Map<List<PedidoDto>>(pedidos);
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
        public List<PedidoProducto> AddProducto(PedidoForProducto dto)
        {
            try
            {
                var newProductos = new List<PedidoProducto>();
                foreach (var productoId in dto.ProductoId)
                {
                    var newProducto = new PedidoProducto
                    {
                        PedidoId = dto.PedidoId,
                        ProductoId = productoId
                    };
                    _context.PedidoProductos.Add(newProducto);
                    newProductos.Add(newProducto);
                }
                _context.SaveChanges();

                return newProductos;
            }
            catch (DbUpdateException ex)
            {
                // Log the error or rethrow the exception with more details
                throw new Exception("There was a problem saving changes: " + ex.InnerException.Message);
            }
        }
        public void UpdatePedido(PedidoForUpdate dto)
        {
            var pedidoItem = _context.Pedido.Include(p => p.PedidoProductos)
                                            .ThenInclude(pp => pp.Producto)
                                            .FirstOrDefault(x => x.Id == dto.Id);

            if (pedidoItem != null)
            {
                pedidoItem.Date = dto.Date;
                pedidoItem.State = dto.State;

                // Obtener los productos existentes
                var existingProducts = pedidoItem.PedidoProductos.ToList();

                // Eliminar los productos existentes que no están en el nuevo listado
                foreach (var existingProduct in existingProducts)
                {
                    if (!dto.ProductoId.Contains(existingProduct.ProductoId))
                    {
                        _context.Entry(existingProduct).State = EntityState.Deleted;
                    }
                }

                // Agregar los nuevos productos que no estaban antes
                foreach (var productoId in dto.ProductoId)
                {
                    if (!existingProducts.Any(ep => ep.ProductoId == productoId))
                    {
                        var producto = _context.Producto.Find(productoId);
                        if (producto != null)
                        {
                            var newPedidoProducto = new PedidoProducto { PedidoId = pedidoItem.Id, ProductoId = productoId };
                            _context.Entry(newPedidoProducto).State = EntityState.Added;
                        }
                    }
                }
                _context.Pedido.Update(pedidoItem); 
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

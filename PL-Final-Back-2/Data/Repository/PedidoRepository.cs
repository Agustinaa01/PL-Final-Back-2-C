
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
                    .ThenInclude(pp => pp.Producto)
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
                for (int i = 0; i < dto.ProductoId.Count; i++)
                {
                    var newProducto = new PedidoProducto
                    {
                        PedidoId = dto.PedidoId,
                        ProductoId = dto.ProductoId[i],
                        Cantidad = dto.Cantidad[i] 
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
                    if (!dto.PedidoProductos.Any(p => p.ProductoId == existingProduct.ProductoId))
                    {
                        _context.Entry(existingProduct).State = EntityState.Deleted;
                    }
                }

                // Actualizar o agregar los nuevos productos
                foreach (var productoDto in dto.PedidoProductos)
                {
                    var existingProduct = existingProducts.FirstOrDefault(ep => ep.ProductoId == productoDto.ProductoId);
                    if (existingProduct != null)
                    {
                        // Actualizar la cantidad si el producto ya existe
                        existingProduct.Cantidad = productoDto.Cantidad;
                        _context.Entry(existingProduct).State = EntityState.Modified;
                    }
                    else
                    {
                        // Agregar el producto si no existía antes
                        var producto = _context.Producto.Find(productoDto.ProductoId);
                        if (producto != null)
                        {
                            var newPedidoProducto = new PedidoProducto { PedidoId = pedidoItem.Id, ProductoId = productoDto.ProductoId, Cantidad = productoDto.Cantidad };
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
            // Find the Pedido with the given Id
            var pedido = _context.Pedido.Include(p => p.PedidoProductos).Single(u => u.Id == Id);

            // Remove all related PedidoProducto entities
            _context.PedidoProductos.RemoveRange(pedido.PedidoProductos);

            // Remove the Pedido
            _context.Pedido.Remove(pedido);

            // Save changes
            _context.SaveChanges();
        }



    }


}


using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            .Include(c=> c.Producto)
            .ToList();
            return pedido;
        }
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
        public void CreatePedido(PedidoForCreation dto)
        {
            _context.Pedido.Add(_mapper.Map<Pedido>(dto));
            _context.SaveChanges();
        }
        public void AddProducto(PedidoForUpdate dto)
        {
            var contact = _context.Producto
                .Where(c => c.Id == dto.ProductoId)
                .Include(c => c.Pedido)
                .FirstOrDefault();
            var group = _context.Pedido.Find(dto.PedidoId);
            contact.Pedido.Add(group);
            _context.SaveChanges();
        }
        public void DeletePedido(int Id)
        {
            _context.Pedido.Remove(_context.Pedido.Single(c => c.Id == Id));
            _context.SaveChanges();
        }

    }


}

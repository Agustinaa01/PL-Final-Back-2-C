using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Tup_Back.Data.Repository
{
    public class ProductoRepository: IProductoRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;
        public ProductoRepository(AgendaApiContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }
        public List<Producto> GetAllProducto()
        {
            var contacts = _context.Producto
                .ToList();
            return contacts;
        }
        public Producto GetProductoById(int id)
        {
            return _context.Producto.Find(id);

        }
        
        public void CreateProducto(ProductoForCreation dto)
        {
            Producto producto = _mapper.Map<Producto>(dto);
            _context.Producto.Add(producto);
            _context.SaveChanges();
        }

        public void UpdateProducto(Producto producto)
        {
            var productoItem = _context.Producto.FirstOrDefault(x => x.Id == producto.Id);

            if (productoItem != null)
            {
                productoItem.Name = producto.Name;
                productoItem.Price = producto.Price;
                productoItem.Description = producto.Description;
                productoItem.Category = producto.Category;
                productoItem.Brand = producto.Brand;
                productoItem.ImageUrl = producto.ImageUrl;

                _context.Producto.Update(productoItem);
                _context.SaveChanges();
            }
        }

        public void DeleteProducto(int Id)
        {
            _context.Producto.Remove(_context.Producto.Single(c => c.Id == Id));
            _context.SaveChanges();
        }
        public void ArchiveProducto(int Id)
        {
            Producto producto = _context.Producto.FirstOrDefault(u => u.Id == Id);
            if (producto != null)
            {
                producto.state = State.Archived;
                _context.Update(producto);
            }
            _context.SaveChanges();
        }

    }


}

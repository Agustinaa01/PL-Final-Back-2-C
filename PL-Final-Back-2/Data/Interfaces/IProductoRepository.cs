﻿using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IProductoRepository
    {
        public List<Producto> GetAllProducto(int id);
        public Producto GetProductoById(int Id);
        public void CreateProducto(ProductoForCreation dto, int Id);
        public void UpdateProducto(Producto producto);
        public void DeleteProducto(int Id);
        public void ArchiveProducto(int Id);

    }
}


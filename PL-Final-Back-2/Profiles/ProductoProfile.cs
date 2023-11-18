using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;

namespace Agenda_Tup_Back.Profiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoForCreation>();
            CreateMap<ProductoForCreation, Producto>();
        }
    }
}

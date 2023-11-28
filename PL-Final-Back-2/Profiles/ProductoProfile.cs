using Agenda_Tup_Back.Data.DTO;
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
            CreateMap<Producto, ProductoDto>();
            CreateMap<PedidoProducto, PedidoProductoDto>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto));
        }
    }
}

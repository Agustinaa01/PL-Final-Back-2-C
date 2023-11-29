using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;

namespace Agenda_Tup_Back.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoForCreation>();
            CreateMap<PedidoForCreation, Pedido>();
            CreateMap<PedidoProducto, PedidoForUpdate>();
            CreateMap<PedidoForUpdate, PedidoProducto>();
            CreateMap<PedidoProducto, PedidoProductoDto>();
            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.PedidoProductos, opt => opt.MapFrom(src => src.PedidoProductos));
        //    CreateMap<PedidoForUpdate, PedidoProducto>()
        //        .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(src => src.PedidoId))
        //        .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId));
        }
    }
}

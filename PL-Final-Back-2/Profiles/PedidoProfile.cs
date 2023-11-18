using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;

namespace Agenda_Tup_Back.Profiles
{
    public class PedidoProfile: Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoForCreation>();
            CreateMap<PedidoForCreation, Pedido>();
        }
    }
}

using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;

namespace Agenda_Tup_Back.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserForCreation>();
            CreateMap<UserForCreation, User>();
        }
    }
}

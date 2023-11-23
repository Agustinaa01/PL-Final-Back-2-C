using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using AutoMapper;

namespace Agenda_Tup_Back.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AgendaApiContext context, IMapper autoMapper)
        { 
            _context = context;
            _mapper = autoMapper;
        }
        public User? GetUserById(int userId)
        {
            return _context.User.SingleOrDefault(u => u.Id == userId);
        }
        public User? ValidarUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.User.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password && p.state == 0 );
        }
        public List<UserForGet> GetAllUsers()
        {
            return _context.User
                .Select(u => new UserForGet
                {
                    Id= u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Rol = u.Rol,
                })
                .ToList();
        }

        public void CreateUsers(UserForCreation dto)
        {
            _context.User.Add(_mapper.Map<User>(dto));
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            var userItem = _context.User.FirstOrDefault(x => x.Id == user.Id);

            if (userItem != null)
            {
                userItem.Name = user.Name;
                userItem.Password = user.Password;
                userItem.Email = user.Email;

                _context.SaveChanges();
            }
        }
        public void DeleteUsers(int id)
        {
            _context.User.Remove(_context.User.Single(u => u.Id == id));
            _context.SaveChanges();
        }

        public void ArchiveUsers(int Id)
        {
            User user = _context.User.FirstOrDefault(u => u.Id == Id);
            if (user != null)
            {
                user.state = State.Archived;
                _context.Update(user);
            }
            _context.SaveChanges();
        }

    }   
}

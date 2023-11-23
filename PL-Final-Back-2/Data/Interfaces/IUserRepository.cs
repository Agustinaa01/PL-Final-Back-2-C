using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidarUser(AuthenticationRequestBody authRequestBody);
        public User GetUserById(int userId);
        public List<UserForGet> GetAllUsers();
        public void CreateUsers(UserForCreation dto);
        public void UpdateUser(User user);
        public void DeleteUsers(int Id);
        public void ArchiveUsers(int Id);

    }
}


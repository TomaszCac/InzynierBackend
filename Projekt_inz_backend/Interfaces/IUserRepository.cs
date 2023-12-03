using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUserById(int id);
        public bool DeleteUser(int id);
        public bool Save();
        public bool VerifyUsername(string username);
        public bool VerifyPassword(UserDto user);
        public bool VerifyEmail(string email);
        public bool CreateUser(User user);
        public string CreateToken(UserDto user);
        public User GetUserByName(string username);


    }
}

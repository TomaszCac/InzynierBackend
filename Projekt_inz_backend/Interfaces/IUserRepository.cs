using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public bool Save();
        public bool VerifyUsername(string username);
        public bool VerifyPassword(UserDto user);
        public bool CreateUser(User user);
        public string CreateToken(UserDto user);


    }
}

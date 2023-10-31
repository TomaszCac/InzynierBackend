using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DndDatabaseContext _context;

        public UserRepository(DndDatabaseContext context)
        {
            _context = context;
        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(b => b.userID).ToList();
        }
    }
}

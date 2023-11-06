using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class EnemyRepository : IEnemyRepository
    {
        private readonly DndDatabaseContext _context;

        public EnemyRepository(DndDatabaseContext context)
        {
            _context = context;
        }

        public ICollection<Enemy> GetEnemies()
        {
            return _context.Enemies.ToList();
        }
    }
}

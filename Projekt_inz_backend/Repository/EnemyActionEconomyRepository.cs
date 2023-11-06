using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class EnemyActionEconomyRepository : IEnemyActionEconomyRepository
    {
        private readonly DndDatabaseContext _context;

        public EnemyActionEconomyRepository(DndDatabaseContext context)
        {
            _context = context;
        }

        public ICollection<EnemyActionEconomy> GetEnemyActionEconomies()
        {
            return _context.enemyActions.ToList();
        }
    }
}

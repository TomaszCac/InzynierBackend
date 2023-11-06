using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Repository
{
    public class EnemyFeatureRepository : IEnemyFeatureRepository
    {
        private readonly DndDatabaseContext _context;

        public EnemyFeatureRepository(DndDatabaseContext context)
        {
            _context = context;
        }

        public ICollection<EnemyFeature> GetEnemyFeatures()
        {
            return _context.enemyFeatures.ToList();
        }
    }
}

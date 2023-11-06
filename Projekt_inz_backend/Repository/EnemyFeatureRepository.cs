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

        public bool CreateEnemyFeature(EnemyFeature feature)
        {
            var enemyEntity = _context.Enemies.Where(b => b.EnemyID == feature.enemyID).FirstOrDefault();
            feature.usedBy = enemyEntity;
            _context.Add(feature);
            return Save();
        }

        public bool DeleteEnemyFeature(EnemyFeature feature)
        {
            _context.Remove(feature);
            return Save();
        }

        public EnemyFeature GetEnemyFeatureByEnemy(int enemyid)
        {
            return _context.enemyFeatures.Where(b => b.enemyID == enemyid).FirstOrDefault();
        }

        public EnemyFeature GetEnemyFeatureById(int id)
        {
            return _context.enemyFeatures.Where(b => b.featureID == id).FirstOrDefault();
        }

        public ICollection<EnemyFeature> GetEnemyFeatures()
        {
            return _context.enemyFeatures.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEnemyFeature(EnemyFeature feature)
        {
            _context.Update(feature);
            return Save();
        }
    }
}

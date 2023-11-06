using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IEnemyFeatureRepository
    {
        public ICollection<EnemyFeature> GetEnemyFeatures();
        public bool Save();
        public bool CreateEnemyFeature(EnemyFeature feature);
        public bool DeleteEnemyFeature(EnemyFeature feature);
        public bool UpdateEnemyFeature(EnemyFeature feature);
        public EnemyFeature GetEnemyFeatureByEnemy(int enemyid);
        public EnemyFeature GetEnemyFeatureById(int id);
    }
}

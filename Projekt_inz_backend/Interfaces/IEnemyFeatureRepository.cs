using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IEnemyFeatureRepository
    {
        public ICollection<EnemyFeature> GetEnemyFeatures();
    }
}

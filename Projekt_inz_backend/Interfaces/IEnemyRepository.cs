using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IEnemyRepository
    {
        public ICollection<Enemy> GetEnemies();
    }
}

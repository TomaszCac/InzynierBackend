using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IEnemyRepository
    {
        public ICollection<Enemy> GetEnemies();
        public bool Save();
        public bool CreateEnemy(int ownerid, Enemy enemy);
        public bool DeleteEnemy(Enemy enemy);
        public bool UpdateEnemy(Enemy enemy);
        public Enemy GetEnemyById(int id);
        public ICollection<Enemy> GetEnemiesByOwner(int ownerid);
    }
}

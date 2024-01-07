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
        public int GetUserIdByName(string username);
        public int GetOwnerId(int enemyId);
        public bool Upvote(int userid, int enemyId);
        public bool CheckUpvote(int userid, int enemyId);
        public ICollection<Enemy> UpvotedList(int userid);
    }
}

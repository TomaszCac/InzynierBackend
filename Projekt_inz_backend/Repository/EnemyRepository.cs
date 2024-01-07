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

        public bool CreateEnemy(int ownerid, Enemy enemy)
        {
            var ownerEntity = _context.Users.Where(b => b.userID == ownerid).FirstOrDefault();
            enemy.owner = ownerEntity;
            _context.Add(enemy);
            return Save();
        }

        public bool DeleteEnemy(Enemy enemy)
        {
            _context.Remove(enemy);
            return Save();
        }

        public ICollection<Enemy> GetEnemies()
        {
            return _context.Enemies.ToList();
        }

        public ICollection<Enemy> GetEnemiesByOwner(int ownerid)
        {
            return _context.Enemies.Where(b => b.owner.userID == ownerid).ToList();
        }

        public Enemy GetEnemyById(int id)
        {
            return _context.Enemies.Where(b => b.enemyId == id).FirstOrDefault();
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }
        public int GetOwnerId(int enemyId)
        {
            return _context.Enemies.Where(b => b.enemyId == enemyId).Select(b => b.owner.userID).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEnemy(Enemy enemy)
        {
            _context.Update(enemy);
            return Save();
        }

        public int Upvotes(int enemyId)
        {
            return _context.upvotes.Where(b => b.category == "enemy" && b.categoryId == enemyId).Count();
        }

        public bool Upvote(int userid, int enemyId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "enemy" && b.userId == userid && b.categoryId == enemyId).FirstOrDefault();
            if (upvote != null)
            {
                _context.upvotes.Remove(upvote);
                return Save();
            }
            upvote = new Upvote();
            upvote.userId = userid;
            upvote.category = "enemy";
            upvote.categoryId = enemyId;
            _context.upvotes.Add(upvote);
            return Save();
        }

        public bool CheckUpvote(int userid, int enemyId)
        {
            Upvote upvote = _context.upvotes.Where(b => b.category == "enemy" && b.userId == userid && b.categoryId == enemyId).FirstOrDefault();
            if (upvote != null)
            {
                return true;
            }
            return false;
        }

        public ICollection<Enemy> UpvotedList(int userid)
        {
            var categoryids = _context.upvotes.Where(b => b.userId == userid && b.category == "enemy").Select(b => b.categoryId).ToList();
            List<Enemy> enemies = new List<Enemy>();
            foreach (var categoryid in categoryids)
            {
                enemies.Add(_context.Enemies.Where(b => b.enemyId == categoryid).FirstOrDefault());
            }
            return enemies;
        }
    }
}

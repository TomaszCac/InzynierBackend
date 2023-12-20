using Microsoft.EntityFrameworkCore.Internal;
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

        public bool CreateEnemyActionEconomy(int enemyid, EnemyActionEconomy action)
        {
            var enemyEntity = _context.Enemies.Where(b => b.enemyId == enemyid).FirstOrDefault();
            action.usedBy = enemyEntity;
            _context.Add(action);
            return Save();
        }

        public bool DeleteEnemyActionEconomy(EnemyActionEconomy action)
        {
            _context.Remove(action);
            return Save();
        }

        public ICollection<EnemyActionEconomy> GetEnemyActionEconomies()
        {
            return _context.enemyActions.ToList();
        }

        public ICollection<EnemyActionEconomy> GetEnemyActionEconomyByEnemy(int enemyid)
        {
            return _context.enemyActions.Where(b => b.usedBy.enemyId == enemyid).ToList();
        }

        public EnemyActionEconomy GetEnemyActionEconomyById(int id)
        {
            return _context.enemyActions.Where(b => b.actionId == id).FirstOrDefault();
        }
        public int GetOwnerId(int enemyId)
        {
            return _context.Enemies.Where(b => b.enemyId == enemyId).Select(b => b.owner.userID).FirstOrDefault();
        }
        public int GetUserIdByName(string username)
        {
            return _context.Users.Where(b => b.username == username).Select(b => b.userID).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEnemyActionEconomy(EnemyActionEconomy action)
        {
            _context.Update(action);
            return Save();
        }
    }
}

using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IEnemyActionEconomyRepository
    {
        public ICollection<EnemyActionEconomy> GetEnemyActionEconomies();
        public ICollection<EnemyActionEconomy> GetEnemyActionEconomyByEnemy(int enemyid);
        public EnemyActionEconomy GetEnemyActionEconomyById(int id);
        public bool Save();
        public bool CreateEnemyActionEconomy(int enemyid, EnemyActionEconomy action);
        public bool DeleteEnemyActionEconomy(EnemyActionEconomy action);
        public bool UpdateEnemyActionEconomy(EnemyActionEconomy action);
        public int GetOwnerId(int enemyId);
        public int GetUserIdByName(string username);
    }
}

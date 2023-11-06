using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Interfaces
{
    public interface IEnemyActionEconomyRepository
    {
        public ICollection<EnemyActionEconomy> GetEnemyActionEconomies();
    }
}

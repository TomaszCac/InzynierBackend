using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class Enemy
    {
        [Key]
        public int EnemyID { get; set; }
        public string EnemyName { get; set; }
        public User owner { get; set; }
        public EnemyFeature? feature { get; set; }
        public ICollection<EnemyActionEconomy> actionEcononomy { get; set; }
    }
}

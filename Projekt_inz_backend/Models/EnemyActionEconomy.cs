using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class EnemyActionEconomy
    {
        [Key]
        public int actionID { get; set; }
        public Enemy usedBy { get; set; }
        public string description {  get; set; }
        public string actionType { get; set; }

    }
}

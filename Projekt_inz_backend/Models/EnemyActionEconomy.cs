using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class EnemyActionEconomy
    {
        [Key]
        public int actionId { get; set; }
        public Enemy usedBy { get; set; }
        public string actionName { get; set; }
        public string actionDesc {  get; set; }
        public string actionType { get; set; }

    }
}

using Projekt_inz_backend.Models;

namespace Projekt_inz_backend.Dto
{
    public class EnemyActionEconomyDto
    {
        public int? actionId { get; set; }
        public string actionName { get; set; }
        public string actionDesc { get; set; }

        public string actionType { get; set; }
    }
}

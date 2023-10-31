using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class RaceFeature
    {
        [Key]
        public int featureID {  get; set; }
        public string abilityScoreIncrease { get; set; }
        public string age { get; set; }
        public string alignment { get; set; }
        public string size { get; set; }
        public string speed { get; set; }
        public string raceDescription { get; set; }
        public int raceID { get; set; }
        public Race usedBy { get; set; }

    }
}

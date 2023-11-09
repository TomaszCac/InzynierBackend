using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class Race
    {
        [Key]
        public int raceID { get; set; }
        public string raceName { get; set; }
        public string tableHeader {  get; set; }
        public string tableData { get; set; }
        public int? inheritedRaceID { get; set; }
        public string abilityScoreIncrease { get; set; }
        public string age { get; set; }
        public string alignment { get; set; }
        public string size { get; set; }
        public string speed { get; set; }
        public string raceDescription { get; set; }
        public string languages { get; set; }
        public User? owner { get; set; }
        public ICollection<CustomRaceFeature> customFeatures { get; set; }
    }
}

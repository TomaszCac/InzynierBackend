using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class Race
    {
        [Key]
        public int raceId { get; set; }
        public string raceName { get; set; }
        public string raceTableHeader {  get; set; }
        public string raceTableData { get; set; }
        public int? inheritedRaceID { get; set; }
        public string raceAbilityScoreIncrease { get; set; }
        public string raceAge { get; set; }
        public string raceAlignment { get; set; }
        public string raceSize { get; set; }
        public string raceSpeed { get; set; }
        public string raceDescription { get; set; }
        public string raceLanguages { get; set; }
        public User? owner { get; set; }
        public string ownerName { get; set; }
        public ICollection<CustomRaceFeature> customFeatures { get; set; }
    }
}

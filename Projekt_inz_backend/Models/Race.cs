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
        public User owner { get; set; }
        public RaceFeature feature { get; set; }
        public ICollection<CustomRaceFeature> customFeatures { get; set; }
    }
}

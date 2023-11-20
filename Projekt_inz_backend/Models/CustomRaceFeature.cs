using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class CustomRaceFeature
    {
        [Key]
        public int featureId { get; set; }
        public Race usedBy { get; set; }
        public string featureName { get; set; }
        public string featureDesc { get; set; }
    }
}

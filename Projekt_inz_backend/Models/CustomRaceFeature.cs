using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class CustomRaceFeature
    {
        [Key]
        public int featureID { get; set; }
        public Race usedBy { get; set; }
        public string featureDesc { get; set; }
    }
}

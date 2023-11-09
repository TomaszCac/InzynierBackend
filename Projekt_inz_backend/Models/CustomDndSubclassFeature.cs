using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class CustomDndSubclassFeature
    {
        [Key]
        public int featureID { get; set; }
        public DndSubclass usedBy { get; set; }
        public string featureName { get; set; }
        public string featureDesc { get; set; }

    }
}

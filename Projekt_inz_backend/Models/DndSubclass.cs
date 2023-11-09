using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class DndSubclass
    {
        [Key]
        public int subclassID {  get; set; }
        public string subclassName { get; set;}
        public string SubclassDesc { get; set;}
        public DndClass inheritedClass { get; set; }
        public User? owner { get; set; }
        ICollection<CustomDndSubclassFeature> customFeatures { get; set; }

    }
}

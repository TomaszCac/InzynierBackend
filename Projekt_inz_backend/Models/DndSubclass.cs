using System.ComponentModel.DataAnnotations;

namespace Projekt_inz_backend.Models
{
    public class DndSubclass
    {
        [Key]
        public int subclassId {  get; set; }
        public string subclassName { get; set;}
        public string subclassDesc { get; set;}
        public DndClass inheritedClass { get; set; }
        public User? owner { get; set; }
        public ICollection<SpellForSubclass> usesSpells { get; set; }
        public string ownerName { get; set; }
        ICollection<CustomDndSubclassFeature> customFeatures { get; set; }

    }
}

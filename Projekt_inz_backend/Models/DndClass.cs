using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_inz_backend.Models
{
    public class DndClass
    {
        [Key]
        public int classID { get; set; }
        public string className { get; set; }
        public string tableHeader {  get; set; }
        public string tableData { get; set; }
        public int? inheritedClassID { get; set; }
        public User owner { get; set; }
        public ICollection<SpellForClass> usesSpells { get; set; }
        public DndClassFeature? feature { get; set; }
        public ICollection<CustomDndClassFeature> customFeatures { get; set; }

    }
}
